using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using AlfredoMB.Stage.Session;
using AlfredoMB.Stage;
using AlfredoMB.PrefabPool;

namespace AlfredoMB.Ship {
	public class ArmorController : Controller, IResetable {
		public ArmorView View;

		private ArmorModel m_thisModel;

		private ArmorModel m_model;
		public ArmorModel Model {
			get {
				return m_model;
			}
			set {
				m_model = value;
				m_thisModel = Object.Instantiate (m_model);
			}
		}

		public ShipModel ShipModel { get; set; }


		public void OnBulletHit(BulletView p_bullet) {
			TakeDamage (p_bullet.Controller.Model.Damage);
		}

		public void TakeDamage(float p_damage) {
			m_thisModel.HitPoints -= p_damage;

			if (m_thisModel.HitPoints <= 0) {
				StageController.Instance.OnShipDestroyed (ShipModel);
				View.Die ();
			}
		}

		#region IResetable implementation

		public void Reset () {
			m_thisModel = Object.Instantiate (m_model);
		}

		#endregion
	}
}