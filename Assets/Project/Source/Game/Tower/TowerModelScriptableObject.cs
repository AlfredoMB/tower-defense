using AlfredoMB.Game.Turret;
using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Tower
{
    [CreateAssetMenu]
    public class TowerModelScriptableObject : ScriptableObject, ISerializedModel<TowerModel>
    {
        public TurretModelScriptableObject Turret;

        public TowerModel TowerModel;

        public TowerModel ToModel()
        {
            TowerModel.Turret = Turret.ToModel();
            return new TowerModel(TowerModel);
        }
    }
}