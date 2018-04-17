using AlfredoMB.Game.Bullet;
using AlfredoMB.MVC;
using AlfredoMB.PrefabPool;
using UnityEngine;

namespace AlfredoMB.Game.Cannon
{
    public class CannonView : MonoBehaviour, IView
    {
        public BulletView bulletPrefab;

		public void FireBullet(BulletModel bulletModel, Vector3 shootForceVector)
        {
			BulletController bullet = PrefabPoolController.GetInstance(bulletPrefab.gameObject).GetComponent<BulletController>();
			bullet.transform.position = transform.position;
			bullet.transform.rotation = transform.rotation;

			bullet.FireTowards (shootForceVector);
		}
	}
}