using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Ship
{
    public class FlightControlController : MonoBehaviour, IController
    {
		private FlightControlModel _model;
		public FlightControlModel Model
        {
			get
            {
				return _model;
			}
			set
            {
				_model = value;
				View.Model = _model;
			}
		}

		public PathFindingFlightControlView View;


		public void MoveTo(Vector3 position)
        {
			View.MoveTo (position);
		}
	}
}