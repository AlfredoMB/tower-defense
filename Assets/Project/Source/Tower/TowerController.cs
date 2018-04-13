using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using System.Collections.Generic;
using AlfredoMB.Tower.Turret;

namespace AlfredoMB.Tower {
	public class TowerController : Controller {
		public TowerModel Model;

		public TurretController Turret;

		private void Awake() {
			Turret.Model = Model.Turret;
		}
	}
}