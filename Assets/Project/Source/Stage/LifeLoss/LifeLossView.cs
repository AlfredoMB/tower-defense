using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using AlfredoMB.PrefabPool;

namespace AlfredoMB.Stage {
	public class LifeLossView : View {

		private void OnTriggerEnter() {
			StageController.Instance.OnEnemyPassed ();
		}
	}
}