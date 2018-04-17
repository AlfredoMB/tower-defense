using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Board
{
    [CreateAssetMenu]
	public class BoardModelScriptableObject : ScriptableObject, ISerializedModel<BoardModel>
    {
        public BoardModel BoardModel;

        public BoardModel ToModel()
        {
            return new BoardModel(BoardModel);
        }
    }
}