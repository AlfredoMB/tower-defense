using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AlfredoMB.MVC;
using AlfredoMB.Ship;
using System;

namespace AlfredoMB.Stage.Session {
	[CreateAssetMenu]
	public class SessionModel : Model {
		public int Money;
		public int Lives;
	}
}