using AlfredoMB.Game.Cannon;
using AlfredoMB.Game.Ship;
using AlfredoMB.MVC;
using System.Collections.Generic;
using UnityEngine;

namespace AlfredoMB.Game.Turret
{
    public class TurretController : MonoBehaviour, IController
    {
		public TurretModel Model { get; set; }
		public TurretView View;

		public CannonController Cannon;

		private List<ShipView> _enemyQueue;


		private void Start()
        {
			View.Model = Model;
			View.Controller = this;

			Cannon.Model = Model.Cannon;

			_enemyQueue = new List<ShipView> ();
		}

		public void AddEnemy(ShipView ship)
        {
			_enemyQueue.Add (ship);
		}

		public void RemoveEnemy(ShipView ship)
        {
			_enemyQueue.Remove (ship);
		}

		private void Update()
        {
			if (_enemyQueue != null && _enemyQueue.Count > 0)
            {
				ShipView currentEnemy = _enemyQueue [0];
				Vector3 toTargetVector = currentEnemy.transform.position - transform.position;

				Quaternion newRotation = Quaternion.Lerp (transform.rotation,Quaternion.LookRotation(toTargetVector), Time.deltaTime * Model.TurnSpeed);

				if (Quaternion.Angle (transform.rotation, newRotation) < 5f)
                {
					Cannon.Fire (toTargetVector);
				}

				transform.rotation = newRotation;

				_enemyQueue.RemoveAll (item => item == null || !item.isActiveAndEnabled);
			}
		}
	}
}