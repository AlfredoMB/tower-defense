using AlfredoMB.Game.Bullet;
using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Cannon
{
    [CreateAssetMenu]
    public class CannonModelScriptableObject : ScriptableObject
    {
        public BulletModelScriptableObject BulletModelScriptableObject;

        public CannonModel CannonModel;
    }
}