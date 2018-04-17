using AlfredoMB.Game.Builder;
using AlfredoMB.Game.Tower;
using AlfredoMB.MVC;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AlfredoMB.Game.Board
{
    [Serializable]
    public class BoardModel : ObservableModel
    {
        public float TileSize;
        public int XTiles;
        public int YTiles;

        public bool[,] OccupiedTiles { get; private set; }
        public List<TowerModel> Towers = new List<TowerModel>();

        public BoardModel(int xTiles, int yTiles)
        {
            XTiles = xTiles;
            YTiles = yTiles;
            OccupiedTiles = new bool[xTiles, yTiles];
        }

        public void Build(TilePosition tilePosition, TowerModel tower)
        {
            var newTower = new TowerModel(tower);

            newTower.SetTilePosition(tilePosition);
            Towers.Add(newTower);

            OccupyTile(tilePosition.TileNE);
            OccupyTile(tilePosition.TileSE);
            OccupyTile(tilePosition.TileNW);
            OccupyTile(tilePosition.TileSW);

            NotifyUpdate();
        }

        private void OccupyTile(Vector3 tilePosition)
        {
            OccupiedTiles[(int)tilePosition.x, (int)tilePosition.z] = true;
        }
        
        public bool IsFree(TilePosition tilePosition)
        {
            return IsFree(tilePosition.TileNE) &&
                IsFree(tilePosition.TileSE) &&
                IsFree(tilePosition.TileNW) &&
                IsFree(tilePosition.TileSW);
        }

        private bool IsFree(Vector3 tilePosition)
        {
            if (tilePosition.x < 0 || tilePosition.x >= OccupiedTiles.GetUpperBound(0) || 
                tilePosition.z < 0 || tilePosition.z >= OccupiedTiles.GetUpperBound(1))
            {
                return false;
            }
            else
            {
                return !OccupiedTiles[(int)tilePosition.x, (int)tilePosition.z];
            }
        }

    }
}