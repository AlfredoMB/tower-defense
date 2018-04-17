using AlfredoMB.Board;
using AlfredoMB.Builder;
using AlfredoMB.MVC;
using AlfredoMB.Stage.EnemySpawn;
using System;

namespace AlfredoMB.Stage
{
    [Serializable]
    public class StageModel : IModel
    {
        public int Lives;
        public int Money;

        public BuilderModel BuilderModel { get; set; }
        public BoardModel BoardModel { get; set; }

		public EnemySpawnModel EnemySpawn { get; set; }

        public StageModel()
        { }

        public StageModel(StageModel stageModel, BuilderModel builderModel, BoardModel boardModel)
        {
            Lives = stageModel.Lives;
            Money = stageModel.Money;

            BuilderModel = builderModel;
            BoardModel = boardModel;
        }
    }
}