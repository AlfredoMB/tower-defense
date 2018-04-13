using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Ship
{
    [CreateAssetMenu]
	public class CannonModel : ScriptableObject, IModel
    {
		public BulletController Bullet;
		public float ShootForce;
		public float ShootCooldown;
	}
}