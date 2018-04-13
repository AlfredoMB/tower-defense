using UnityEngine;
using AlfredoMB.MVC;
using AlfredoMB.Ship;

namespace AlfredoMB.Tower.Turret
{
    public class TurretView : MonoBehaviour, IView
    {
		public Transform ActionRadius;

		private TurretModel _model;
		public TurretModel Model
        { 
			get
            { 
				return _model;
			} 
			set
            {
				_model = value;
				UpdateActionRadius ();
			}
		}
		public TurretController Controller { get; set; }


		private void UpdateActionRadius()
        {
			ActionRadius.localScale = Vector3.one * Model.ActionRadius;
		}

		private void OnTriggerEnter(Collider collider)
        {
			ShipView ship = collider.gameObject.GetComponent<ShipView> ();
			if (ship != null)
            {
				Controller.AddEnemy (ship);
			}
		}

		private void OnTriggerExit(Collider collider)
        {
			ShipView ship = collider.gameObject.GetComponent<ShipView> ();
			if (ship != null)
            {
				Controller.RemoveEnemy (ship);
			}
		}
	}
}