using AlfredoMB.Command;
using AlfredoMB.DI;
using AlfredoMB.Game.Tower;
using AlfredoMB.Stage;
using System;
using UnityEngine;

namespace AlfredoMB.Game.Builder
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