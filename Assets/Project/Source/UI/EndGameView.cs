using UnityEngine;
using AlfredoMB.MVC;

namespace AlfredoMB.UI
{
	public class EndGameView : MonoBehaviour, IView
    {
		public GameObject EndGameScreen;

		protected virtual bool IsTimeToActivate()
        {
			return false;
		}

		private void Update()
        {
			EndGameScreen.SetActive (IsTimeToActivate());
		}
	}
}