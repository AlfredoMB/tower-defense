using AlfredoMB.Game.Ship;
using AlfredoMB.MVC;
using System;
using System.Collections.Generic;

namespace AlfredoMB.Game.Radar
{
    [Serializable]
    public class RadarModel : ObservableModel
    {
        public float ActionRadius;

        public List<ShipView> EnemiesOnRadar = new List<ShipView>();
                
        public void AddEnemy(ShipView ship)
        {
            EnemiesOnRadar.Add(ship);
            NotifyUpdate();
        }

        public void RemoveEnemy(ShipView ship)
        {
            EnemiesOnRadar.Remove(ship);
            NotifyUpdate();
        }
    }
}
