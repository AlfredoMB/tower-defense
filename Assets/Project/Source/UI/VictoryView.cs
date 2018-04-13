using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using AlfredoMB.Ship;
using AlfredoMB.UI;
using AlfredoMB.Stage;

namespace AlfredoMB.UI {
	public class VictoryView : EndGameView {
		protected override bool IsTimeToActivate() {
			return StageController.Instance.IsVictory;
		}
	}
}