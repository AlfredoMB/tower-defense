using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Tower
{
    [CreateAssetMenu]
    public class TowerModelScriptableObject : ScriptableObject, ISerializedModel<TowerModel>
    {
        public TurretModelScriptableObject Turret;

        public TowerModel TowerModel;

        public TowerModel ToModel()
        {
            return new TowerModel(TowerModel, Turret.ToModel());
        }
    }
}