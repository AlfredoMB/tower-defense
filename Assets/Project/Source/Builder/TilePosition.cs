using AlfredoMB.Board;
using System;
using UnityEngine;

namespace AlfredoMB.Builder
{
    [Serializable]
    public class TilePosition
    {
        public Vector3 WorldPosition;
        public Vector3 LogicTilePosition;

        public Vector3 TileNE;
        public Vector3 TileSE;
        public Vector3 TileNW;
        public Vector3 TileSW;

        private static Vector3 _tilePositionNE = new Vector3(0, 0, 0);
        private static Vector3 _tilePositionSE = new Vector3(0, 0, -1);
        private static Vector3 _tilePositionNW = new Vector3(-1, 0, 0);
        private static Vector3 _tilePositionSW = new Vector3(-1, 0, -1);
                
        public TilePosition(Vector3 position, BoardModel boardModel)
        {
            WorldPosition = position;

            LogicTilePosition = (position / boardModel.TileSize) + new Vector3(boardModel.XTiles * 0.5f, 0, boardModel.YTiles * 0.5f);

            TileNE = (LogicTilePosition + _tilePositionNE);
            TileSE = (LogicTilePosition + _tilePositionSE);
            TileNW = (LogicTilePosition + _tilePositionNW);
            TileSW = (LogicTilePosition + _tilePositionSW);
        }
    }
}