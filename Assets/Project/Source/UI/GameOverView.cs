using AlfredoMB.Stage;

namespace AlfredoMB.UI
{
	public class GameOverView : EndGameView
    {
		protected override bool IsTimeToActivate()
        {
			return StageController.Instance.IsGameOver;
		}
	}
}