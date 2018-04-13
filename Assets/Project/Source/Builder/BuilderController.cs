using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using System;
using AlfredoMB.Tower;
using AlfredoMB.Stage.Session;

namespace AlfredoMB.Builder {
	public class BuilderController : Controller {
		public BuilderModel Model;
		public BuilderView View;

		public TowerController CurrentTower;

		public TowerController Tower1;
		public TowerController Tower2;


		private bool[,] m_occupiedTiles;


		private void Start() {
			m_occupiedTiles = new bool[Model.XTiles, Model.YTiles];

			View.Model = Model;
			View.Controller = this;
		}

		private void OnDrawGizmos() {
			if (m_occupiedTiles != null) { 
				for (int i = 0; i < m_occupiedTiles.GetUpperBound (0); i++) {
					for (int j = 0; j < m_occupiedTiles.GetUpperBound (1); j++) {
						Vector3 center = transform.position + new Vector3 (i, 0, j) * Model.TileSize + new Vector3 (1, 0, 1) * Model.TileSize * 0.5f;
						Vector3 size = Vector3.one * Model.TileSize;

						if (m_occupiedTiles [i, j]) {
							Gizmos.color = Color.red;
							Gizmos.DrawCube (center, size);
						} else {
							Gizmos.color = Color.green;
							Gizmos.DrawWireCube (center, size);
						}
					}
				}
			}
		}

		public bool IsFree(Vector3 p_tilePosition) {
			if (p_tilePosition.x < 0 || p_tilePosition.x >= Model.XTiles - 1 || p_tilePosition.z < 0 || p_tilePosition.z >= Model.YTiles - 1) {
				return false;
			} else {
				return !m_occupiedTiles [(int)p_tilePosition.x, (int)p_tilePosition.z];
			}
		}

		private void OccupyTile(Vector3 p_tilePosition) {
			m_occupiedTiles [(int)p_tilePosition.x, (int)p_tilePosition.z] = true;
		}

		private bool HasMoneyToBuild() {
			return SessionController.Instance.Model.Money >= CurrentTower.Model.Cost;
		}

		private void SpendMoney() {
			SessionController.Instance.Model.Money -= CurrentTower.Model.Cost;
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Alpha1)) {
				CurrentTower = Tower1;
			}

			if (Input.GetKeyDown(KeyCode.Alpha2)) {
				CurrentTower = Tower2;
			}

			if (UnityEngine.Input.GetMouseButtonDown(0)) {
				if (View.ReadyToBuild && HasMoneyToBuild()) {
					SpendMoney ();

					OccupyTile (View.CurrentTileNE);
					OccupyTile (View.CurrentTileSE);
					OccupyTile (View.CurrentTileNW);
					OccupyTile (View.CurrentTileSW);
						
					View.Build (CurrentTower.gameObject);
				}
			}
		}
	}
}