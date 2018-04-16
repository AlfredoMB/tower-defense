using AlfredoMB.MVC;
using System.Collections.Generic;
using AlfredoMB.DI;
using UnityEngine;

namespace AlfredoMB.Stage.EnemySpawn
{
    public class EnemySpawnController : MonoBehaviour, IController
    {
		public EnemySpawnView View;

		public Transform Destination;

		private float _time;
		private List<EnemySpawnModel.SpawnModel> _spawnList;

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
				_spawnList = new List<EnemySpawnModel.SpawnModel> (Model.SpawnList);
			}
		}
        
        private IStageController _stageController;

        private void Start()
        {
            _stageController = SimpleDI.Get<IStageController>();
        }

        private void Update()
        {
			_time += Time.deltaTime;

			foreach(EnemySpawnModel.SpawnModel spawn in _spawnList)
            {
				if (spawn.Time <= _time)
                {
                    _stageController.OnShipSpawned ();
					View.Spawn(spawn, Destination);
				}
			}
			_spawnList.RemoveAll (item => item.Time <= _time);

			if (_spawnList.Count <= 0)
            {
                _stageController.AllEnemiesSpawned ();
			}
		}

	}
}