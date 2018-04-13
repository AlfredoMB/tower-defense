using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AlfredoMB.MVC;

namespace AlfredoMB.Ship {
	[CreateAssetMenu]
	public class CannonModel : Model {
		public BulletController Bullet;
		public float ShootForce;
		public float ShootCooldown;
	}
}