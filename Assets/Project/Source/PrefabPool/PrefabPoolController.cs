using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using AlfredoMB.MVC;

namespace AlfredoMB.PrefabPool {
	public class PrefabPoolController : Controller {
		private static PrefabPoolController m_instance;

		private List<PrefabPool> m_prefabPoolList;

		private class PrefabPool {
			private GameObject m_prefab;
			private List<GameObject> m_objectsInPool;
			private Transform parentForObjectsInPool;

			public PrefabPool(GameObject p_prefab, Transform p_parent, int p_startSize) {
				m_prefab = p_prefab;
				GameObject go = new GameObject(p_prefab.name + "Pool");
				go.transform.parent = p_parent;
				parentForObjectsInPool = go.transform;

				m_objectsInPool = new List<GameObject>();
				for(int i=0; i<p_startSize; i++) {
					m_objectsInPool.Add(Instantiate());
				}
			}

			public bool IsPoolFor(GameObject p_prefab) {
				return m_prefab == p_prefab;
			}

			public GameObject GetInstance() {
				GameObject instance = null;

				if (m_objectsInPool.Count > 0) {
					instance = m_objectsInPool [0];
					m_objectsInPool.Remove (instance);
				} else {
					instance = GameObject.Instantiate (m_prefab);
				}

				instance.transform.parent = null;
				instance.SetActive (true);
				return instance;
			}

			private GameObject Instantiate() {
				GameObject newInstance = GameObject.Instantiate (m_prefab);
				newInstance.transform.parent = parentForObjectsInPool;
				return newInstance;
			}

			public void ReturnInstance(GameObject p_prefab) {
				IResetable[] resetables = p_prefab.GetComponentsInChildren<IResetable> (true);
				foreach (IResetable resetable in resetables) {
					resetable.Reset ();
				}

				p_prefab.SetActive (false);
				p_prefab.transform.parent = parentForObjectsInPool;
				m_objectsInPool.Add (p_prefab);
			}
		}


		private void Awake() {
			m_instance = this;
			m_prefabPoolList = new List<PrefabPool> ();
		}

		public static GameObject GetInstance(GameObject p_prefab) {
			PrefabPool pool = m_instance.GetPrefabPool (p_prefab);
			return pool.GetInstance ();
		}

		private PrefabPool GetPrefabPool(GameObject p_prefab) {
			PrefabPool thisPrefabPool = null;

			// find pool
			foreach(PrefabPool pool in m_prefabPoolList) {
				if (pool.IsPoolFor (p_prefab)) {
					thisPrefabPool = pool;
					break;
				}
			}

			// new pool
			if (thisPrefabPool == null) {
				thisPrefabPool = CreatePool (p_prefab);
			}

			return thisPrefabPool;
		}

		private PrefabPool CreatePool (GameObject p_prefab, int p_startSize = 0) {
			PrefabPool thisPrefabPool = new PrefabPool (p_prefab, transform, p_startSize);
			m_prefabPoolList.Add (thisPrefabPool);
			return thisPrefabPool;
		}

		public static void ReturnInstance(GameObject p_prefab) {
			PrefabPool pool = m_instance.GetPrefabPool (p_prefab);
			pool.ReturnInstance (p_prefab);
		}
	}
}