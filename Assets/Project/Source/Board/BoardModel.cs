using AlfredoMB.Builder;
using AlfredoMB.MVC;
using AlfredoMB.Tower;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AlfredoMB.Board
{
    [Serializable]
    public class BoardModel : ObservableModel
    {
        public float TileSize = 4f;
        public int XTiles;
        public int YTiles;

        public bool[,] OccupiedTiles { get; private set; }
        public List<TowerModel> Towers { get; private set; }
        
        public BoardModel(BoardModel reference)
        {
            TileSize = reference.TileSize;
            XTiles = reference.XTiles;
            YTiles = reference.YTiles;

            OccupiedTiles = new bool[XTiles, YTiles];
            Towers = new List<TowerModel>();
        }

        public void Build(TilePosition tilePosition, TowerModel tower)
        {
            tower.SetTilePosition(tilePosition);
            Towers.Add(tower);

            OccupyTile(tilePosition.TileNE);
            OccupyTile(tilePosition.TileSE);
            OccupyTile(tilePosition.TileNW);
            OccupyTile(tilePosition.TileSW);

            if (OnUpdated != null)
            {
                OnUpdated();
            }
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