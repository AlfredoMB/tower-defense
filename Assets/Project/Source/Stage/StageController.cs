using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using System.Collections.Generic;
using AlfredoMB.Stage.EnemySpawn;
using AlfredoMB.Ship;
using AlfredoMB.Stage.Session;
using UnityEngine.SceneManagement;

namespace AlfredoMB.Stage {
	public class StageController : Controller {
		public static StageController Instance;

		public StageModel Model;
		public StageView View;

		public EnemySpawnController EnemySpawn;

		public LifeLossView LifeLoss;

		private int m_enemiesSpawned;

		private bool m_allEnemiesSpawned;

		public bool IsGameOver { get { return SessionController.Instance.Model.Lives <= 0; } }
		public bool IsVictory { get { return m_allEnemiesSpawned && m_enemiesSpawned <= 0; } }


		private void Awake() {
			Instance = this;
		}

		private void Start() {
			EnemySpawn.Model = Model.EnemySpawn;
		}

		public void OnEnemyPassed() {
			SessionController.Instance.Model.Lives--;
		}

		public void OnShipDestroyed(ShipModel p_destroyedShip) {
			SessionController.Instance.Model.Money += p_destroyedShip.ScoreValue;
			m_enemiesSpawned--;
		}

		public void OnShipSpawned() {
			m_enemiesSpawned++;
		}

		public void AllEnemiesSpawned() {
			m_allEnemiesSpawned = true;
		}
	}
}