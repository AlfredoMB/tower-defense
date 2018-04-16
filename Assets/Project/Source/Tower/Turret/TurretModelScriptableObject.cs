using AlfredoMB.MVC;
using UnityEngine;
using AlfredoMB.Tower.Turret;

namespace AlfredoMB.Tower
{
    [CreateAssetMenu]
    public class TurretModelScriptableObject : ScriptableObject, ISerializedModel<TurretModel>
    {
        public TurretModel TurretModel;

        public TurretModel ToModel()
        {
            return new TurretModel(TurretModel);
        }
    }
}