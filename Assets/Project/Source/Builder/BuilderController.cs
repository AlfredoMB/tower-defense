using AlfredoMB.MVC;
using AlfredoMB.Stage.Session;
using AlfredoMB.Tower;
using UnityEngine;

namespace AlfredoMB.Builder
{
    public class BuilderController : MonoBehaviour, IController
    {
		public BuilderModel Model;
		public BuilderView View;

		public TowerController CurrentTower;

		public TowerController Tower1;
		public TowerController Tower2;


		private bool[,] _occupiedTiles;


		private void Start()
        {
			_occupiedTiles = new bool[Model.XTiles, Model.YTiles];

			View.Model = Model;
			View.Controller = this;
		}

		private void OnDrawGizmos()
        {
			if (_occupiedTiles != null)
            { 
				for (int i = 0; i < _occupiedTiles.GetUpperBound (0); i++)
                {
					for (int j = 0; j < _occupiedTiles.GetUpperBound (1); j++)
                    {
						Vector3 center = transform.position + new Vector3 (i, 0, j) * Model.TileSize + new Vector3 (1, 0, 1) * Model.TileSize * 0.5f;
						Vector3 size = Vector3.one * Model.TileSize;

						if (_occupiedTiles [i, j])
                        {
							Gizmos.color = Color.red;
							Gizmos.DrawCube (center, size);
						}
                        else
                        {
							Gizmos.color = Color.green;
							Gizmos.DrawWireCube (center, size);
						}
					}
				}
			}
		}

		public bool IsFree(Vector3 p_tilePosition)
        {
			if (p_tilePosition.x < 0 || p_tilePosition.x >= Model.XTiles - 1 || p_tilePosition.z < 0 || p_tilePosition.z >= Model.YTiles - 1)
            {
				return false;
			}
            else
            {
				return !_occupiedTiles [(int)p_tilePosition.x, (int)p_tilePosition.z];
			}
		}

		private void OccupyTile(Vector3 p_tilePosition)
        {
			_occupiedTiles [(int)p_tilePosition.x, (int)p_tilePosition.z] = true;
		}

		private bool HasMoneyToBuild()
        {
			return SessionController.Instance.Model.Money >= CurrentTower.Model.Cost;
		}

		private void SpendMoney()
        {
			SessionController.Instance.Model.Money -= CurrentTower.Model.Cost;
		}

		private void Update()
        {
			if (Input.GetKeyDown(KeyCode.Alpha1))
            {
				CurrentTower = Tower1;
			}

			if (Input.GetKeyDown(KeyCode.Alpha2))
            {
				CurrentTower = Tower2;
			}

			if (UnityEngine.Input.GetMouseButtonDown(0))
            {
				if (View.ReadyToBuild && HasMoneyToBuild())
                {
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