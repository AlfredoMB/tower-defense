using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AlfredoMB.MVC;
using AlfredoMB.Tower.Turret;

namespace AlfredoMB.Tower {
	[CreateAssetMenu]
	public class TowerModel : Model {
		public TurretModel Turret;
		public int Cost;
		public string Name;
	}
}