using AlfredoMB.MVC;
using AlfredoMB.Tower.Turret;
using UnityEngine;

namespace AlfredoMB.Tower
{
    public class TowerController : MonoBehaviour, IController
    {
		public TowerModel Model;

		public TurretController Turret;

		private void Awake()
        {
			Turret.Model = Model.Turret;
		}
	}
}