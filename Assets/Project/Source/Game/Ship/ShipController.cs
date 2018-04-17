using AlfredoMB.Game.Armor;
using AlfredoMB.Game.FlightControl;
using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Ship
{
    public class ShipController : MonoBehaviour, IController
    {
		public ShipModel Model;

		private FlightControlController FlightControl;
		private ArmorController Armor;

		private void Awake()
        {
			// get components
			FlightControl = GetComponent<FlightControlController> ();
			Armor = GetComponent<ArmorController> ();

			// initialize components
			FlightControl.Model = Model.FlightControl;
			Armor.Model = Model.Armor;
			Armor.ShipModel = Model;
		}

		public void MoveTo(Vector3 position)
        {
			FlightControl.MoveTo (position);
		}
	}
}