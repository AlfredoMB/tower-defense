using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using System.Collections.Generic;
using AlfredoMB.Ship;

namespace AlfredoMB.Tower.Turret {
	public class TurretController : Controller {
		public TurretModel Model { get; set; }
		public TurretView View;

		public CannonController Cannon;

		private List<ShipView> m_enemyQueue;


		private void Start() {
			View.Model = Model;
			View.Controller = this;

			Cannon.Model = Model.Cannon;

			m_enemyQueue = new List<ShipView> ();
		}

		public void AddEnemy(ShipView p_ship) {
			m_enemyQueue.Add (p_ship);
		}

		public void RemoveEnemy(ShipView p_ship) {
			m_enemyQueue.Remove (p_ship);
		}

		private void Update() {
			if (m_enemyQueue != null && m_enemyQueue.Count > 0) {
				ShipView currentEnemy = m_enemyQueue [0];
				Vector3 toTargetVector = currentEnemy.transform.position - transform.position;

				Quaternion newRotation = Quaternion.Lerp (transform.rotation,Quaternion.LookRotation(toTargetVector), Time.deltaTime * Model.TurnSpeed);

				if (Quaternion.Angle (transform.rotation, newRotation) < 5f) {
					Cannon.Fire (toTargetVector);
				}

				transform.rotation = newRotation;

				m_enemyQueue.RemoveAll (item => item == null || !item.isActiveAndEnabled);
			}
		}
	}
}