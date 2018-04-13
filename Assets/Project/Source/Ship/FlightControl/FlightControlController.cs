using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;

namespace AlfredoMB.Ship {
	public class FlightControlController : Controller {
		private FlightControlModel m_model;
		public FlightControlModel Model {
			get {
				return m_model;
			}
			set {
				m_model = value;
				View.Model = m_model;
			}
		}

		public PathFindingFlightControlView View;


		public void MoveTo(Vector3 p_position) {
			View.MoveTo (p_position);
		}
	}
}