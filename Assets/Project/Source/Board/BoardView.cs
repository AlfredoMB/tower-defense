using AlfredoMB.MVC;
using AlfredoMB.PrefabPool;
using AlfredoMB.Stage;
using AlfredoMB.Tower;
using AlfredoMB.DI;
using System.Collections.Generic;
using UnityEngine;

namespace AlfredoMB.Board
{
    /// <summary>
    /// Instantiates/removes towers based on model update.
    /// </summary>
    public class BoardView : MonoBehaviour, IView
    {
        public TowerView Tower1;
        public TowerView Tower2;

        private IStageController _stageController;

        private List<TowerView> _instantiatedTowers = new List<TowerView>();

        private void Start()
        {
            _stageController = SimpleDI.Get<IStageController>();
        }

        private void OnEnable()
        {
            _stageController.CurrentState.Board.OnUpdated += OnModelUpdated;
        }

        private void OnDisable()
        {
            _stageController.CurrentState.Board.OnUpdated -= OnModelUpdated;
        }

        private void OnModelUpdated()
        {
            foreach(var tower in _stageController.CurrentState.Board.Towers)
            {
                if (_instantiatedTowers.Find(instantiated => instantiated.Model == tower) != null)
                {
                    continue;
                }

                Build(Tower1, tower);
            }
        }

        private void Build(TowerView towerPrefab, TowerModel tower)
        {
            GameObject newTower = PrefabPoolController.GetInstance(towerPrefab.gameObject);
            newTower.transform.position = tower.TilePosition.WorldPosition;
            _instantiatedTowers.Add(newTower.GetComponent<TowerView>());
        }

        private void OnDrawGizmos()
        {
            var board = _stageController.CurrentState.Board;
            if (board.OccupiedTiles != null)
            {
                for (int i = 0; i < board.OccupiedTiles.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < board.OccupiedTiles.GetUpperBound(1); j++)
                    {
                        Vector3 center = transform.position + new Vector3(i, 0, j) * board.TileSize + new Vector3(1, 0, 1) * board.TileSize * 0.5f;
                        Vector3 size = Vector3.one * board.TileSize;

                        if (board.OccupiedTiles[i, j])
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawCube(center, size);
                        }
                        else
                        {
                            Gizmos.color = Color.green;
                            Gizmos.DrawWireCube(center, size);
                        }
                    }
                }
            }
        }
    }
}
