using UnityEngine;
using AlfredoMB.MVC;
using AlfredoMB.Tower.Turret;
using System.Collections.Generic;
using AlfredoMB.Builder;
using System;

namespace AlfredoMB.Tower
{
    [Serializable]
	public class TowerModel : IModel, IRecipe
    {        
		public int Cost;
		public string Name;

        public TurretModel Turret { get; private set; }
        public TilePosition TilePosition { get; private set; }

        private Dictionary<object, int> _cost;

        public TowerModel(TowerModel towerModel, TurretModel turretModel)
        {
            Turret = turretModel;
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