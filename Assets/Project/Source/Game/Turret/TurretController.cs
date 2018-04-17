using AlfredoMB.Game.Cannon;
using AlfredoMB.Game.Radar;
using AlfredoMB.Game.Ship;
using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Turret
{
    public class TurretController : IController
    {
		private TurretModel _model;
        private RadarModel _radarModel;
        private Transform _viewTransform;

        private CannonController _cannon;

        private const float _shootingAngle = 5f;

        public TurretController(TurretModel model, RadarModel radarModel, Transform viewTransform, CannonView cannonView)
        {
            _model = model;
            _radarModel = radarModel;
            _viewTransform = viewTransform;

            _cannon = new CannonController(_model.Cannon, cannonView);
        }
        
		public void Update()
        {
            var enemyQueue = _radarModel.EnemiesOnRadar;
			if (enemyQueue != null && enemyQueue.Count > 0)
            {
				ShipView currentEnemy = enemyQueue[0];

                // rotate towards enemy
				Vector3 toTargetVector = currentEnemy.transform.position - _viewTransform.position;

				Quaternion newRotation = Quaternion.Lerp(_viewTransform.rotation, 
                    Quaternion.LookRotation(toTargetVector), 
                    Time.deltaTime * _model.TurnSpeed);
                
                _viewTransform.rotation = newRotation;

                // if on shooting angle,
                if (Quaternion.Angle(_viewTransform.rotation, newRotation) < _shootingAngle)
                {
                    // shoot
                    _cannon.Fire(toTargetVector);
                }

                // remove dead enemies?
                enemyQueue.RemoveAll (item => item == null || !item.isActiveAndEnabled);
			}

            _cannon.Update();
		}
	}
}