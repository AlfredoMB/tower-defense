using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Board
{
    [CreateAssetMenu]
	public class BoardModelScriptableObject : ScriptableObject, ISerializedModel<BoardModel>
    {
        public float TileSize;
        public int XTiles;
        public int YTiles;

        public BoardModel ToModel()
        {
            return new BoardModel(XTiles, YTiles)
            {
                TileSize = TileSize
            };
        }
    }
}