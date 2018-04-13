using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Tower
{
    public class TowerView : MonoBehaviour, IView
    {
		public TowerModel Model { get; set; }
		public TowerController Controller { get; set; }

		private void Update()
        {
		}
	}
}