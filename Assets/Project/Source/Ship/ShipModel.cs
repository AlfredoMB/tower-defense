using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AlfredoMB.MVC;

namespace AlfredoMB.Ship {
	[CreateAssetMenu]
	public class ShipModel : Model {
		public FlightControlModel FlightControl;
		public ArmorModel Armor;
		public int ScoreValue;
	}
}