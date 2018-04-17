using AlfredoMB.Game.Bullet;
using AlfredoMB.MVC;
using AlfredoMB.PrefabPool;
using UnityEngine;

namespace AlfredoMB.Game.Armor
{
    public class ArmorView : MonoBehaviour, IView
    {
		public ArmorController Controller;

		private void OnTriggerEnter(Collider collider)
        {
			BulletView bullet = collider.gameObject.GetComponent<BulletView> ();
			if (bullet != null)
            {
				Controller.OnBulletHit (bullet);
			}
		}

		public void Die()
        {
			GameObject explosion = PrefabPoolController.GetInstance(Controller.Model.Explosion);
			explosion.transform.position = transform.position;
			explosion.transform.rotation = transform.rotation;

			PrefabPoolController.ReturnInstance (gameObject);
		}
	}
}