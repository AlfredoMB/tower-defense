using AlfredoMB.Game.Cannon;
using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Turret
{
    [CreateAssetMenu]
    public class TurretModelScriptableObject : ScriptableObject, ISerializedModel<TurretModel>
    {
        public CannonModelScriptableObject CannonModelScriptableObject;

        public float TurnSpeed;

        public TurretModel ToModel()
        {
            return new TurretModel()
            {
                TurnSpeed = TurnSpeed,
                Cannon = CannonModelScriptableObject.ToModel()                
            };
        }
    }
}