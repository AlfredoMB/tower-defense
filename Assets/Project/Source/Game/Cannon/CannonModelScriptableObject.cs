using AlfredoMB.Game.Bullet;
using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Cannon
{
    [CreateAssetMenu]
    public class CannonModelScriptableObject : ScriptableObject, ISerializedModel<CannonModel>
    {
        public BulletModelScriptableObject BulletModelScriptableObject;

        public float ShootForce;
        public float ShootCooldown;

        public CannonModel ToModel()
        {
            return new CannonModel()
            {
                ShootForce = ShootForce,
                ShootCooldown = ShootCooldown,
                BulletModel = BulletModelScriptableObject.ToModel()
            };
        }
    }
}