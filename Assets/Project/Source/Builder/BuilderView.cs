using AlfredoMB.MVC;
using AlfredoMB.PrefabPool;
using UnityEngine;

namespace AlfredoMB.Builder
{
    public class BuilderView : MonoBehaviour, IView
    {
		public BuilderModel Model { get; set; }
		public BuilderController Controller { get; set; }

		public GameObject Reference;

		public bool ReadyToBuild { get; private set; }

		public Vector3 CurrentTileNE;
		public Vector3 CurrentTileSE;
		public Vector3 CurrentTileNW;
		public Vector3 CurrentTileSW;

		private Renderer[] _meshRenderers;


		private void Start()
        {
			_meshRenderers = Reference.GetComponentsInChildren<Renderer> ();
		}

		private void Update()
        {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint (UnityEngine.Input.mousePosition);
			mousePosition.y = 0;

			Vector3 TilePosition = new Vector3 (Mathf.RoundToInt(mousePosition.x / Model.TileSize) * Model.TileSize, 0, Mathf.RoundToInt(mousePosition.z / Model.TileSize) * Model.TileSize);

			Reference.transform.position = TilePosition;

			Vector3 LogicTilePosition = (TilePosition - transform.position) / Model.TileSize;

			Vector3 tilePositionNE = new Vector3 (0, 0, 0);
			Vector3 tilePositionSE = new Vector3 (0, 0, -1);
			Vector3 tilePositionNW = new Vector3 (-1, 0, 0);
			Vector3 tilePositionSW = new Vector3 (-1, 0, -1);

			CurrentTileNE = (LogicTilePosition + tilePositionNE);
			CurrentTileSE = (LogicTilePosition + tilePositionSE);
			CurrentTileNW = (LogicTilePosition + tilePositionNW);
			CurrentTileSW = (LogicTilePosition + tilePositionSW);

			ReadyToBuild = Controller.IsFree (CurrentTileNE) &&
				Controller.IsFree (CurrentTileSE) &&
				Controller.IsFree (CurrentTileNW) &&
				Controller.IsFree (CurrentTileSW);

			SetColor ((ReadyToBuild) ? Color.green : Color.red);
		}

		private void SetColor(Color color)
        {
			foreach(MeshRenderer renderer in _meshRenderers)
            {
				renderer.material.color = color;
			}
		}

		public void Build(GameObject prefab)
        {
			GameObject newTower = PrefabPoolController.GetInstance(prefab.gameObject);
			newTower.transform.position = Reference.transform.position;
		}
	}
}