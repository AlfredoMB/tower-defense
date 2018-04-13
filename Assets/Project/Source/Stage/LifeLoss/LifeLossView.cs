using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Stage
{
    public class LifeLossView : MonoBehaviour, IView
    {
		private void OnTriggerEnter()
        {
			StageController.Instance.OnEnemyPassed ();
		}
	}
}