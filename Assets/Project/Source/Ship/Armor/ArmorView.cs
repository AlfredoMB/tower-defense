using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using AlfredoMB.PrefabPool;
using AlfredoMB.Stage;

namespace AlfredoMB.Ship {
	public class ArmorView : View {
		public ArmorController Controller;

		private void OnTriggerEnter(Collider p_collider) {
			BulletView bullet = p_collider.gameObject.GetComponent<BulletView> ();
			if (bullet != null) {
				Controller.OnBulletHit (bullet);
			}
		}

		public void Die() {
			GameObject explosion = PrefabPoolController.GetInstance(Controller.Model.Explosion);
			explosion.transform.position = transform.position;
			explosion.transform.rotation = transform.rotation;

			PrefabPoolController.ReturnInstance (gameObject);
		}
	}
}