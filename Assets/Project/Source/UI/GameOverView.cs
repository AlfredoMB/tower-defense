using AlfredoMB.Stage;
using AlfredoMB.DI;

namespace AlfredoMB.UI
{
	public class GameOverView : EndGameView
    {
        private IStageController _stageController;

        private void Start()
        {
            _stageController = SimpleDI.Get<IStageController>();
        }

        protected override bool IsTimeToActivate()
        {
			return _stageController.IsGameOver;
		}
	}
}