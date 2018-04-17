using AlfredoMB.Game.Board;
using AlfredoMB.Game.Builder;
using AlfredoMB.Game.Tower;
using NUnit.Framework;
using UnityEngine;

namespace AlfredoMB.Board.Tests
{
    public class BoardModelTests
    {
        [Test]
        public void ConstructorTest()
        {
            var boardModel = new BoardModel(10, 10)
            {
                TileSize = 1
            };
            
            Assert.That(boardModel.Towers, Is.Not.Null);
            Assert.That(boardModel.OccupiedTiles, Is.Not.Null);
        }

        [Test]
        public void BuildTest()
        {
            var boardModel = new BoardModel(10, 10)
            {
                TileSize = 1
            };

            bool wasOnUpdatedCalled = false;
            boardModel.OnUpdated += () =>
            {
                wasOnUpdatedCalled = true;
            };

            var position = Vector3.one;
            var tilePosition = new TilePosition(position, boardModel);
            var towerModel = new TowerModel();

            boardModel.Build(tilePosition, towerModel);

            CollectionAssert.Contains(boardModel.Towers, towerModel);

            Assert.That(boardModel.OccupiedTiles[5, 5], Is.True);
            Assert.That(boardModel.OccupiedTiles[5, 6], Is.True);
            Assert.That(boardModel.OccupiedTiles[6, 5], Is.True);
            Assert.That(boardModel.OccupiedTiles[6, 6], Is.True);

            Assert.That(wasOnUpdatedCalled, Is.True);

            Assert.That(boardModel.IsFree(tilePosition), Is.False);
        }
    }
}
