using AlfredoMB.MVC;
using System.Collections.Generic;
using UnityEngine;

namespace AlfredoMB.Stage.EnemySpawn
{
    public class EnemySpawnController : MonoBehaviour, IController
    {
		public EnemySpawnView View;

		public Transform Destination;

		private float _time;
		private List<SpawnModel> _spawnList;

		private EnemySpawnModel m_model;
		public EnemySpawnModel Model
        { 
			get
            {
				return m_model;
			}

			set
            {
				m_model = value;
				_time = 0;
				_spawnList = new List<SpawnModel> (Model.SpawnList);
			}
		}


		private void Update()
        {
			_time += Time.deltaTime;

			foreach(SpawnModel spawn in _spawnList)
            {
				if (spawn.Time <= _time)
                {
					StageController.Instance.OnShipSpawned ();
					View.Spawn(spawn, Destination);
				}
			}
			_spawnList.RemoveAll (item => item.Time <= _time);

			if (_spawnList.Count <= 0)
            {
				StageController.Instance.AllEnemiesSpawned ();
			}
		}

	}
}