using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AlfredoMB.MVC;

namespace AlfredoMB.Ship {
	[CreateAssetMenu]
	public class FlightControlModel : Model {
		public float Speed;
		public float RotationSpeed;
	}
}