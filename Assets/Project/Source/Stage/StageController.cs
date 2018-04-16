using UnityEngine;
using AlfredoMB.Ship;
using AlfredoMB.Board;

namespace AlfredoMB.Stage
{
    public class StageController : IStageController
    {
		public StageModel CurrentState { get; private set; }

		private int _enemiesSpawned;
		private bool _allEnemiesSpawned;

        public bool IsGameOver { get { return CurrentState.Lives <= 0; } }
		public bool IsVictory { get { return _allEnemiesSpawned && _enemiesSpawned <= 0; } }
        
        public StageController(StageModel model)
        {
            CurrentState = model;
        }
        
		public void OnEnemyPassed()
        {
            CurrentState.Lives--;
		}

		public void OnShipDestroyed(ShipModel p_destroyedShip)
        {
            CurrentState.Money += p_destroyedShip.ScoreValue;
			_enemiesSpawned--;
		}

		public void OnShipSpawned()
        {
			_enemiesSpawned++;
		}

		public void AllEnemiesSpawned()
        {
			_allEnemiesSpawned = true;
		}
	}
}