using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using AlfredoMB.Ship;
using AlfredoMB.UI;
using AlfredoMB.Stage.Session;

namespace AlfredoMB.UI {
	public class LivesView : View {
		public SessionModel Model { get; set; }

		public GameObject Life1;
		public GameObject Life2;
		public GameObject Life3;

		private void Update() {
			Life1.SetActive (Model.Lives >= 1);
			Life2.SetActive (Model.Lives >= 2);
			Life3.SetActive (Model.Lives >= 3);

		}
	}
}