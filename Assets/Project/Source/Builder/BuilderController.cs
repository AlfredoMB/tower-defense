using AlfredoMB.Board;
using AlfredoMB.Command;
using AlfredoMB.DI;
using AlfredoMB.Stage;
using AlfredoMB.Tower;
using System;
using UnityEngine;

namespace AlfredoMB.Builder
{
    /// <summary>
    /// Changes BoardModel based on BuildTowerCommand
    /// </summary>
    public class BuilderController : IBuilderController, IDisposable
    {
        private ICommandController _commandController;
        private IStageController _stage;

        public BuilderController()
        {
            _commandController = SimpleDI.Get<ICommandController>();
            _commandController.AddListener<BuildTowerCommand>(OnBuildTowerCommand);

            _stage = SimpleDI.Get<IStageController>();
            _stage.CurrentState.BuilderModel.SelectTower(0);
        }

        public void Dispose()
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
            var tilePosition = new TilePosition(position, _stage.CurrentState.BoardModel);

            if (CanBuild(tilePosition) && HasMoneyToBuild(tower))
            {
                SpendMoney(tower);
                _stage.CurrentState.BoardModel.Build(tilePosition, tower);
            }
        }

        private bool CanBuild(TilePosition tilePosition)
        {
            return _stage.CurrentState.BoardModel.IsFree(tilePosition);
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