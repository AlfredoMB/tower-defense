using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using System.Collections.Generic;

namespace AlfredoMB.Ship {
	public class ShipController : Controller {
		public ShipModel Model;

		private FlightControlController FlightControl;
		private ArmorController Armor;

		private void Awake() {
			// get components
			FlightControl = GetComponent<FlightControlController> ();
			Armor = GetComponent<ArmorController> ();

			// initialize components
			FlightControl.Model = Model.FlightControl;
			Armor.Model = Model.Armor;
			Armor.ShipModel = Model;
		}

		public void MoveTo(Vector3 p_position) {
			FlightControl.MoveTo (p_position);
		}

	}
}