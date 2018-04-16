using AlfredoMB.Board;
using AlfredoMB.Builder;
using AlfredoMB.Command;
using AlfredoMB.DI;
using AlfredoMB.DI.Decoupling;
using AlfredoMB.DI.Decoupling.UnityImplementations;
using AlfredoMB.Stage;
using UnityEngine;

namespace AlfredoMB.Initialization
{
    public class GameInitializer : MonoBehaviour
    {
        public GameObject Views;

        public BoardModelScriptableObject BoardScriptableObject;
        public StageModelScriptableObject StageScriptableObject;

        private void Start()
        {
            // register dependencies
            SimpleDI.Register<ICamera>(new UnityCamera());
            SimpleDI.Register<IInput>(new UnityInput());
            SimpleDI.Register<ICommandController>( new CommandController());

            var boardModel = new BoardModel(BoardScriptableObject.BoardModel);
            var stageModel = new StageModel(StageScriptableObject.StageModel);

            SimpleDI.Register<IStageController>(new StageController(stageModel, boardModel));
            SimpleDI.Register<IBuilderController>(new BuilderController(boardModel));

            Views.SetActive(true);
        }
    }
}