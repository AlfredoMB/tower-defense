using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using AlfredoMB.PrefabPool;
using AlfredoMB.Ship;

namespace AlfredoMB.Tower.Turret {
	public class TurretView : View {

		public Transform ActionRadius;

		private TurretModel m_model;
		public TurretModel Model { 
			get { 
				return m_model;
			} 
			set {
				m_model = value;
				UpdateActionRadius ();
			}
		}
		public TurretController Controller { get; set; }


		private void UpdateActionRadius() {
			ActionRadius.localScale = Vector3.one * Model.ActionRadius;
		}

		private void OnTriggerEnter(Collider p_collider) {
			ShipView ship = p_collider.gameObject.GetComponent<ShipView> ();
			if (ship != null) {
				Controller.AddEnemy (ship);
			}
		}

		private void OnTriggerExit(Collider p_collider) {
			ShipView ship = p_collider.gameObject.GetComponent<ShipView> ();
			if (ship != null) {
				Controller.RemoveEnemy (ship);
			}
		}


	}
}