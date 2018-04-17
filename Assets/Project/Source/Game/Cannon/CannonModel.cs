using AlfredoMB.Game.Bullet;
using AlfredoMB.MVC;

namespace AlfredoMB.Game.Cannon
{
	public class CannonModel : IModel
    {
		public BulletController Bullet;
		public float ShootForce;
		public float ShootCooldown;
	}
}