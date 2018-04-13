using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;

namespace AlfredoMB.Ship {
	public class CannonController : Controller {
		public CannonModel Model { get; set; }
		public CannonView View;

		private float m_fireCooldown;


		public void Fire(Vector3 p_direction) {
			if (m_fireCooldown > 0) {
				return;				
			}

			View.FireBullet(Model.Bullet, Model.ShootForce * p_direction);

			m_fireCooldown = Model.ShootCooldown;
		}

		private void Update() {
			if (m_fireCooldown > 0) {
				m_fireCooldown -= Time.deltaTime;
			}
		}
	}
}