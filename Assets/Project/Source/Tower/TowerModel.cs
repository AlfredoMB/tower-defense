using UnityEngine;
using AlfredoMB.MVC;
using AlfredoMB.Tower.Turret;
using System.Collections.Generic;
using AlfredoMB.Builder;
using System;

namespace AlfredoMB.Tower
{
	[CreateAssetMenu]
	public class TowerModel : ScriptableObject, IModel, IRecipe
    {        
		public TurretModel Turret;
		public int Cost;
		public string Name;

        public TilePosition TilePosition { get; private set; }

        private Dictionary<object, int> _cost;

        public Dictionary<object, int> GetCost()
        {
            // TODO: change 'this' to item.
            return _cost ?? (_cost = new Dictionary<object, int>() { { this, Cost } });
        }

        public void SetPosition(TilePosition tilePosition)
        {
            TilePosition = tilePosition;
        }
    }
}