using AlfredoMB.MVC;
using AlfredoMB.PrefabPool;
using AlfredoMB.Stage;
using UnityEngine;

namespace AlfredoMB.Ship
{
    public class ArmorController : MonoBehaviour, IController, IResetable
    {
		public ArmorView View;

		private ArmorModel _thisModel;

		private ArmorModel _model;
		public ArmorModel Model
        {
			get
            {
				return _model;
			}
			set
            {
				_model = value;
				_thisModel = Object.Instantiate (_model);
			}
		}

		public ShipModel ShipModel { get; set; }


		public void OnBulletHit(BulletView bullet)
        {
			TakeDamage (bullet.Controller.Model.Damage);
		}

		public void TakeDamage(float damage)
        {
			_thisModel.HitPoints -= damage;

			if (_thisModel.HitPoints <= 0)
            {
				StageController.Instance.OnShipDestroyed (ShipModel);
				View.Die ();
			}
		}

		#region IResetable implementation

		public void Reset ()
        {
			_thisModel = Object.Instantiate (_model);
		}

		#endregion
	}
}