using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using AlfredoMB.Ship;
using AlfredoMB.UI;
using AlfredoMB.Stage.Session;

namespace AlfredoMB.UI {
	public class EndGameView : View {

		public GameObject EndGameScreen;

		protected virtual bool IsTimeToActivate() {
			return false;
		}

		private void Update() {
			EndGameScreen.SetActive (IsTimeToActivate());
		}
	}
}