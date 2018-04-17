using AlfredoMB.Game.Bullet;
using AlfredoMB.MVC;
using System;

namespace AlfredoMB.Game.Cannon
{
    [Serializable]
	public class CannonModel : IModel
    {
		public float ShootForce;
		public float ShootCooldown;

        public BulletModel BulletModel;
    }
}