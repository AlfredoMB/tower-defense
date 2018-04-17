﻿using AlfredoMB.Board;
using AlfredoMB.Command;
using AlfredoMB.DI;
using AlfredoMB.Ship;
using AlfredoMB.Stage;
using AlfredoMB.Tower;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AlfredoMB.Builder.Tests
{
    public class BuilderControllerTests
    {
        private class CommandControllerStub : ICommandController
        {
            public ICommand AddedCommand;
            public Action<ICommand> AddedListener;

            public void AddCommand(ICommand command)
            {
                AddedCommand = command;
            }

            public void AddListener<T>(Action<ICommand> listener) where T : ICommand
            {
                AddedListener = listener;
            }

            public void RemoveListener<T>(Action<ICommand> listener) where T : ICommand
            {
                Assert.That(AddedListener, Is.EqualTo(listener));
                AddedListener = null;
            }
        }

        private class StageControllerStub : IStageController
        {
            public StageModel CurrentState { get; set; }
            public bool IsGameOver { get; set; }
            public bool IsVictory { get; set; }

            public void AllEnemiesSpawned()
            {
                throw new NotImplementedException();
            }

            public void OnEnemyPassed()
            {
                throw new NotImplementedException();
            }

            public void OnShipDestroyed(ShipModel destroyedShip)
            {
                throw new NotImplementedException();
            }

            public void OnShipSpawned()
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        public void ConstructorTest()
        {
            var commandController = new CommandControllerStub();
            var stageController = new StageControllerStub()
            {
                CurrentState = new StageModel()
                {
                    BuilderModel = new BuilderModel()
                    {
                        AvailableTowers = new List<TowerModel>()
                        {
                            new TowerModel()
                        }
                    }
                }
            };

            SimpleDI.Reset();
            SimpleDI.Register<ICommandController>(commandController);
            SimpleDI.Register<IStageController>(stageController);

            var builderController = new BuilderController();

            Assert.That(commandController.AddedListener, Is.Not.Null);
            Assert.That(stageController.CurrentState.BuilderModel.SelectedTower, Is.Not.Null);
            
            builderController.Dispose();
            Assert.That(commandController.AddedListener, Is.Null);
        }
        
        [Test]
        public void OnBuildTowerCommandTest()
        {
            var towerModel = new TowerModel();
            var commandController = new CommandControllerStub();
            var stageController = new StageControllerStub()
            {
                CurrentState = new StageModel()
                {
                    BuilderModel = new BuilderModel()
                    {
                        AvailableTowers = new List<TowerModel>()
                        {
                            towerModel
                        }
                    },
                    BoardModel = new BoardModel()
                    {
                        TileSize = 1,
                        XTiles = 10,
                        YTiles = 10
                    }
                }
            };

            stageController.CurrentState.BoardModel.Initialize();

            SimpleDI.Reset();
            SimpleDI.Register<ICommandController>(commandController);
            SimpleDI.Register<IStageController>(stageController);

            var builderController = new BuilderController();

            commandController.AddedListener(new BuildTowerCommand(Vector3.one, towerModel));

            CollectionAssert.Contains(stageController.CurrentState.BoardModel.Towers, towerModel);
        }
    }
}
