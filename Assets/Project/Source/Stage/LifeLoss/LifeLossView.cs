using AlfredoMB.MVC;
using AlfredoMB.DI;
using UnityEngine;

namespace AlfredoMB.Stage
{
    public class LifeLossView : MonoBehaviour, IView
    {
        private IStageController _stageController;

        private void Start()
        {
            _stageController = SimpleDI.Get<IStageController>();
        }

        private void OnTriggerEnter()
        {
            _stageController.OnEnemyPassed ();
		}
	}
}