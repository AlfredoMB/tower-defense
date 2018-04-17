using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Cannon
{
    public class CannonController : IController
    {
		private CannonModel _model;
        private CannonView _cannonView;

        private float _fireCooldown;

        public CannonController(CannonModel model, CannonView cannonView)
        {
            _model = model;
            _cannonView = cannonView;
        }

        public void Fire(Vector3 direction)
        {
			if (_fireCooldown > 0)
            {
				return;				
			}

            _cannonView.FireBullet(_model.BulletModel, _model.ShootForce * direction);

			_fireCooldown = _model.ShootCooldown;
		}

		public void Update()
        {
			if (_fireCooldown > 0)
            {
				_fireCooldown -= Time.deltaTime;
			}
		}
	}
}