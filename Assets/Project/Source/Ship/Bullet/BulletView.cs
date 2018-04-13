using AlfredoMB.MVC;
using AlfredoMB.PrefabPool;
using UnityEngine;

namespace AlfredoMB.Ship
{
    public class BulletView : MonoBehaviour, IView
    {
		public BulletController Controller;

		private void OnTriggerEnter()
        {
			PrefabPoolController.ReturnInstance(gameObject);
		}
	}
}