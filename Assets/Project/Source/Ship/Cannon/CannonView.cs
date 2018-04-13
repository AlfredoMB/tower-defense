using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using AlfredoMB.PrefabPool;

namespace AlfredoMB.Ship {
	public class CannonView : View {

		public void FireBullet(BulletController p_bulletPrefab, Vector3 p_shootForceVector) {
			BulletController bullet = PrefabPoolController.GetInstance(p_bulletPrefab.gameObject).GetComponent<BulletController>();
			bullet.transform.position = transform.position;
			bullet.transform.rotation = transform.rotation;

			bullet.FireTowards (p_shootForceVector);
		}
	}
}