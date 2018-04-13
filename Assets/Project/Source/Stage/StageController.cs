using UnityEngine;
using AlfredoMB.MVC;
using AlfredoMB.Stage.EnemySpawn;
using AlfredoMB.Ship;
using AlfredoMB.Stage.Session;

namespace AlfredoMB.Stage
{
    public class StageController : MonoBehaviour, IController
    {
		public static StageController Instance;

		public StageModel Model;
		public StageView View;

		public EnemySpawnController EnemySpawn;

		public LifeLossView LifeLoss;

		private int _enemiesSpawned;

		private bool _allEnemiesSpawned;

		public bool IsGameOver { get { return SessionController.Instance.Model.Lives <= 0; } }
		public bool IsVictory { get { return _allEnemiesSpawned && _enemiesSpawned <= 0; } }


		private void Awake()
        {
			Instance = this;
		}

		private void Start()
        {
			EnemySpawn.Model = Model.EnemySpawn;
		}

		public void OnEnemyPassed()
        {
			SessionController.Instance.Model.Lives--;
		}

		public void OnShipDestroyed(ShipModel p_destroyedShip)
        {
			SessionController.Instance.Model.Money += p_destroyedShip.ScoreValue;
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