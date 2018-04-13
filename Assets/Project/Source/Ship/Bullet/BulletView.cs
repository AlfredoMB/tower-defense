using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using AlfredoMB.PrefabPool;

namespace AlfredoMB.Ship {
	public class BulletView : View {
		public BulletController Controller;

		private void OnTriggerEnter() {
			PrefabPoolController.ReturnInstance(gameObject);
		}
	}
}