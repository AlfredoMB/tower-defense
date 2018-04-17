using AlfredoMB.Game.Builder;
using AlfredoMB.Game.Radar;
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

        public TurretModel Turret { get; set; }
        public RadarModel Radar { get; set; }

        public TilePosition TilePosition { get; private set; }

        private Dictionary<object, int> _cost;

        private TowerModel _originalModel;

        public TowerModel()
        { }

        public TowerModel(TowerModel originalModel)
        {
            _originalModel = originalModel;

            Cost = originalModel.Cost;
            Name = originalModel.Name;
            Turret = originalModel.Turret;
            Radar = originalModel.Radar;
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