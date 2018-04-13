using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AlfredoMB.MVC;
using AlfredoMB.Ship;

namespace AlfredoMB.Tower.Turret {
	[CreateAssetMenu]
	public class TurretModel : Model {
		public CannonModel Cannon;
		public float TurnSpeed;
		public float ActionRadius;
	}
}