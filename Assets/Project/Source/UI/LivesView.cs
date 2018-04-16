using UnityEngine;
using AlfredoMB.MVC;
using AlfredoMB.Stage;
using AlfredoMB.DI;

namespace AlfredoMB.UI
{
	public class LivesView : MonoBehaviour, IView
    {
		public GameObject Life1;
		public GameObject Life2;
		public GameObject Life3;

        private IStageController _stageController;

        private void Start()
        {
            _stageController = SimpleDI.Get<IStageController>();
        }

        private void Update()
        {
			Life1.SetActive (_stageController.CurrentState.Lives >= 1);
			Life2.SetActive (_stageController.CurrentState.Lives >= 2);
			Life3.SetActive (_stageController.CurrentState.Lives >= 3);
		}
	}
}