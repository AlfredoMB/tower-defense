using AlfredoMB.MVC;
using System.Collections.Generic;
using UnityEngine;

namespace AlfredoMB.PrefabPool
{
    public class PrefabPoolController : MonoBehaviour, IController
    {
		private static PrefabPoolController _instance;

		private List<PrefabPool> _prefabPoolList;

		private class PrefabPool
        {
			private GameObject _prefab;
			private List<GameObject> _objectsInPool;
			private Transform _parentForObjectsInPool;

			public PrefabPool(GameObject prefab, Transform parent, int startSize)
            {
				_prefab = prefab;
				GameObject go = new GameObject(prefab.name + "Pool");
				go.transform.parent = parent;
				_parentForObjectsInPool = go.transform;

				_objectsInPool = new List<GameObject>();
				for(int i=0; i<startSize; i++)
                {
					_objectsInPool.Add(Instantiate());
				}
			}

			public bool IsPoolFor(GameObject prefab)
            {
				return _prefab == prefab;
			}

			public GameObject GetInstance()
            {
				GameObject instance = null;

				if (_objectsInPool.Count > 0)
                {
					instance = _objectsInPool [0];
					_objectsInPool.Remove (instance);
				}
                else
                {
					instance = GameObject.Instantiate (_prefab);
				}

				instance.transform.parent = null;
				instance.SetActive (true);
				return instance;
			}

			private GameObject Instantiate()
            {
				GameObject newInstance = GameObject.Instantiate (_prefab);
				newInstance.transform.parent = _parentForObjectsInPool;
				return newInstance;
			}

			public void ReturnInstance(GameObject prefab)
            {
				IResetable[] resetables = prefab.GetComponentsInChildren<IResetable> (true);
				foreach (IResetable resetable in resetables)
                {
					resetable.Reset ();
				}

				prefab.SetActive (false);
				prefab.transform.parent = _parentForObjectsInPool;
				_objectsInPool.Add (prefab);
			}
		}


		private void Awake()
        {
			_instance = this;
			_prefabPoolList = new List<PrefabPool> ();
		}

		public static GameObject GetInstance(GameObject prefab)
        {
			PrefabPool pool = _instance.GetPrefabPool (prefab);
			return pool.GetInstance ();
		}

		private PrefabPool GetPrefabPool(GameObject prefab)
        {
			PrefabPool thisPrefabPool = null;

			// find pool
			foreach(PrefabPool pool in _prefabPoolList)
            {
				if (pool.IsPoolFor (prefab))
                {
					thisPrefabPool = pool;
					break;
				}
			}

			// new pool
			if (thisPrefabPool == null)
            {
				thisPrefabPool = CreatePool (prefab);
			}

			return thisPrefabPool;
		}

		private PrefabPool CreatePool (GameObject prefab, int startSize = 0)
        {
			PrefabPool thisPrefabPool = new PrefabPool (prefab, transform, startSize);
			_prefabPoolList.Add (thisPrefabPool);
			return thisPrefabPool;
		}

		public static void ReturnInstance(GameObject prefab)
        {
			PrefabPool pool = _instance.GetPrefabPool (prefab);
			pool.ReturnInstance (prefab);
		}
	}
}