using AlfredoMB.Game.Builder;
using AlfredoMB.Game.Tower;
using AlfredoMB.MVC;    
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AlfredoMB.Builder
{
    public class BuilderModelTests
    {
        [Test]
        public void ConstructorTest()
        {
            var builderModel = new BuilderModel()
            {
                AvailableTowers = new List<TowerModel>()
            };

            var newBuilderModel = new BuilderModel(builderModel);

            Assert.That(newBuilderModel.AvailableTowers, Is.EqualTo(builderModel.AvailableTowers));
        }

        [Test]
        public void SelectTowerTest()
        {
            var towerModel = new TowerModel();
            var builderModel = new BuilderModel()
            {
                AvailableTowers = new List<TowerModel>()
                {
                    towerModel
                }
            };

            builderModel.SelectTower(0);

            Assert.That(builderModel.SelectedTower, Is.EqualTo(towerModel));
        }
    }
}
