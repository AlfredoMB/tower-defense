using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using System.Collections.Generic;

namespace AlfredoMB.Stage.EnemySpawn {
	public class EnemySpawnController : Controller {
		public EnemySpawnView View;

		public Transform Destination;

		private float m_time;
		private List<SpawnModel> m_spawnList;

		private EnemySpawnModel m_model;
		public EnemySpawnModel Model { 
			get {
				return m_model;
			}

			set {
				m_model = value;
				m_time = 0;
				m_spawnList = new List<SpawnModel> (Model.SpawnList);
			}
		}


		private void Update() {
			m_time += Time.deltaTime;

			foreach(SpawnModel spawn in m_spawnList) {
				if (spawn.Time <= m_time) {
					StageController.Instance.OnShipSpawned ();
					View.Spawn(spawn, Destination);
				}
			}
			m_spawnList.RemoveAll (item => item.Time <= m_time);

			if (m_spawnList.Count <= 0) {
				StageController.Instance.AllEnemiesSpawned ();
			}
		}

	}
}