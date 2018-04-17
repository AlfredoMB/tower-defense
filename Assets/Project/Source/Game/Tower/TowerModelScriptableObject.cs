using AlfredoMB.Game.Radar;
using AlfredoMB.Game.Turret;
using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Tower
{
    [CreateAssetMenu]
    public class TowerModelScriptableObject : ScriptableObject, ISerializedModel<TowerModel>
    {
        public TurretModelScriptableObject Turret;
        public RadarModelScriptableObject Radar;

        public int Cost;
        public string Name;

        public TowerModel ToModel()
        {
            return new TowerModel()
            {
                Cost = Cost,
                Name = Name,
                Turret = Turret.ToModel(),
                Radar = Radar.ToModel()
            };
        }
    }
}