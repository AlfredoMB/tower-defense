using AlfredoMB.MVC;
using AlfredoMB.Stage.EnemySpawn;
using AlfredoMB.Board;
using AlfredoMB.Tower;
using System;

namespace AlfredoMB.Stage
{
    [Serializable]
    public class StageModel : IModel
    {
        public int Lives;
		public int Money;

        public StageModel(StageModel stageModel)
        {
            Lives = stageModel.Lives;
            Money = stageModel.Money;
        }

        public BoardModel Board { get; set; }
		public EnemySpawnModel EnemySpawn { get; set; }

        public TowerModel SelectedTower;
    }
}