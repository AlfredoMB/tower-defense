using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using System.Collections.Generic;
using AlfredoMB.Ship;

namespace AlfredoMB.Stage.Session {
	public class SessionController : Controller {
		public static SessionController Instance;

		public SessionModel Model;
		public SessionView View;


		private void Awake() {
			Instance = this;
		}

		private void Start() {
			Model.Money = StageController.Instance.Model.StartingMoney;
			Model.Lives = StageController.Instance.Model.StartingLives;

			View.Model = Model;
		}
	}
}