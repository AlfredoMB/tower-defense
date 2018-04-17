using AlfredoMB.DI;
using AlfredoMB.Game.Tower;
using AlfredoMB.MVC;
using AlfredoMB.PrefabPool;
using AlfredoMB.Stage;
using System.Collections.Generic;
using UnityEngine;

namespace AlfredoMB.Game.Board
{
    /// <summary>
    /// Instantiates/removes towers based on model update.
    /// </summary>
    public class BoardView : MonoBehaviour, IView
    {
        public TowerView[] TowerPrefabs;

        private IStageController _stageController;

        private List<TowerView> _instantiatedTowers = new List<TowerView>();
        
        private void OnEnable()
        {
            _stageController = SimpleDI.Get<IStageController>();
            _stageController.CurrentState.BoardModel.OnUpdated += OnModelUpdated;
        }

        private void OnDisable()
        {
            _stageController.CurrentState.BoardModel.OnUpdated -= OnModelUpdated;
        }

        private void OnModelUpdated()
        {
            var towers = _stageController.CurrentState.BoardModel.Towers;
            foreach (var tower in towers)
            {
                if (_instantiatedTowers.Find(instantiated => instantiated.Model == tower) != null)
                {
                    continue;
                }

                // TODO: always Tower1 for now
                Build(TowerPrefabs[0], tower);
            }
        }

        private void Build(TowerView towerPrefab, TowerModel tower)
        {
            GameObject newTower = PrefabPoolController.GetInstance(towerPrefab.gameObject);
            newTower.transform.position = tower.TilePosition.WorldPosition;
            var towerView = newTower.GetComponent<TowerView>();
            towerView.SetModel(tower);
            _instantiatedTowers.Add(towerView);
        }

        /*
        private void OnDrawGizmos()
        {
            var board = _stageController.CurrentState.BoardModel;
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
        */
    }
}
