using AlfredoMB.Board;
using AlfredoMB.Command;
using AlfredoMB.DI;
using AlfredoMB.Stage;
using AlfredoMB.Tower;
using UnityEngine;

namespace AlfredoMB.Builder
{
    /// <summary>
    /// Changes BoardModel based on BuildTowerCommand
    /// </summary>
    public class BuilderController : IBuilderController
    {
        private BoardModel _boardModel;

        private ICommandController _commandController;
        private IStageController _stage;

        public BuilderController(BoardModel boardModel)
        {
            _boardModel = boardModel;

            _commandController = SimpleDI.Get<ICommandController>();
            _commandController.AddListener<BuildTowerCommand>(OnBuildTowerCommand);

            _stage = SimpleDI.Get<IStageController>();
        }

        ~BuilderController()
        {
            if (_commandController != null)
            {
                _commandController.RemoveListener<BuildTowerCommand>(OnBuildTowerCommand);
            }
        }

        private void OnBuildTowerCommand(ICommand command)
        {
            var buildCommand = command as BuildTowerCommand;
            TryToBuild(buildCommand.Position, buildCommand.Tower);
        }

        private void TryToBuild(Vector3 position, TowerModel tower)
        {
            var tilePosition = new TilePosition(position, _boardModel);

            if (CanBuild(tilePosition) && HasMoneyToBuild(tower))
            {
                SpendMoney(tower);
                _boardModel.Build(tilePosition, tower);
            }
        }

        private bool CanBuild(TilePosition tilePosition)
        {
            return _boardModel.IsFree(tilePosition);
        }

        private bool HasMoneyToBuild(TowerModel tower)
        {
            return _stage.CurrentState.Money >= tower.Cost;
        }

        private void SpendMoney(TowerModel tower)
        {
            _stage.CurrentState.Money -= tower.Cost;
        }        
    }
}