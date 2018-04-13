﻿using AlfredoMB.Stage;

namespace AlfredoMB.UI
{
	public class VictoryView : EndGameView
    {
		protected override bool IsTimeToActivate()
        {
			return StageController.Instance.IsVictory;
		}
	}
}