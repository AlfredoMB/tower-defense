using AlfredoMB.Game.Radar;
using AlfredoMB.Game.Ship;
using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Tower
{
    public class RadarView : MonoBehaviour, IView
    {
        private RadarModel _model;

        public void SetModel(RadarModel model)
        {
            _model = model;
            UpdateActionRadius();
        }

        private void UpdateActionRadius()
        {
			transform.localScale = Vector3.one * _model.ActionRadius;
		}

		private void OnTriggerEnter(Collider collider)
        {
			var ship = collider.gameObject.GetComponent<ShipView>();
			if (ship != null)
            {
                _model.AddEnemy(ship);
			}
		}

		private void OnTriggerExit(Collider collider)
        {
			var ship = collider.gameObject.GetComponent<ShipView>();
			if (ship != null)
            {
                _model.RemoveEnemy (ship);
            }
		}
	}
}