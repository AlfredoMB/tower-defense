using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Bullet
{
    [CreateAssetMenu]
    public class BulletModelScriptableObject : ScriptableObject, ISerializedModel<BulletModel>
    {
        public float Damage;
        public float Mass;

        public BulletModel ToModel()
        {
            return new BulletModel()
            {
                Damage = Damage,
                Mass = Mass
            };
        }
    }
}