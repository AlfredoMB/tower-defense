using AlfredoMB.Board;
using AlfredoMB.Builder;
using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Stage
{
    [CreateAssetMenu]
	public class StageModelScriptableObject : ScriptableObject, ISerializedModel<StageModel>
    {
        public BoardModelScriptableObject BoardModelScriptableObject;
        public BuilderModelScriptableObject BuilderModelScriptableObject;

        public StageModel StageModel;

        public StageModel ToModel()
        {
            var boardModel = BoardModelScriptableObject.ToModel();
            var builderModel = BuilderModelScriptableObject.ToModel();

            return new StageModel(StageModel, builderModel, boardModel);
        }
    }
}