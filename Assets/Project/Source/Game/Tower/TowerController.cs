using AlfredoMB.Game.Turret;
using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Tower
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