using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Cannon
{
    public class CannonController : MonoBehaviour, IController
    {
		public CannonModel Model { get; set; }
		public CannonView View;

		private float _fireCooldown;


		public void Fire(Vector3 direction)
        {
			if (_fireCooldown > 0)
            {
				return;				
			}

			View.FireBullet(Model.Bullet, Model.ShootForce * direction);

			_fireCooldown = Model.ShootCooldown;
		}

		private void Update()
        {
			if (_fireCooldown > 0)
            {
				_fireCooldown -= Time.deltaTime;
			}
		}
	}
}