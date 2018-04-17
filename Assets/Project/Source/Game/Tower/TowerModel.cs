using AlfredoMB.Game.Builder;
using AlfredoMB.Game.Turret;
using AlfredoMB.MVC;
using System;
using System.Collections.Generic;

namespace AlfredoMB.Game.Tower
{
    [Serializable]
	public class TowerModel : IModel, IRecipe
    {        
		public int Cost;
		public string Name;

        public TurretModel Turret;

        public TilePosition TilePosition { get; private set; }

        private Dictionary<object, int> _cost;

        public TowerModel()
        { }

        public TowerModel(TowerModel towerModel)
        {
            Cost = towerModel.Cost;
            Name = towerModel.Name;
        }

        public Dictionary<object, int> GetCost()
        {
            // TODO: change 'this' to item.
            return _cost ?? (_cost = new Dictionary<object, int>() { { this, Cost } });
        }

        public void SetTilePosition(TilePosition tilePosition)
        {
            TilePosition = tilePosition;
        }
    }
}