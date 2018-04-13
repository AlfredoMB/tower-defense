using AlfredoMB.MVC;
using AlfredoMB.PrefabPool;
using UnityEngine;

namespace AlfredoMB.Ship
{
    public class CannonView : MonoBehaviour, IView
    {
		public void FireBullet(BulletController bulletPrefab, Vector3 shootForceVector)
        {
			BulletController bullet = PrefabPoolController.GetInstance(bulletPrefab.gameObject).GetComponent<BulletController>();
			bullet.transform.position = transform.position;
			bullet.transform.rotation = transform.rotation;

			bullet.FireTowards (shootForceVector);
		}
	}
}