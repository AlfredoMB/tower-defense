using UnityEngine;
using AlfredoMB.MVC;
using UnityEngine.UI;

namespace AlfredoMB.UI
{
	public class ScoreView : MonoBehaviour, IView
    {
		public enum ScoreTypes
        {
			Money,
			Lives,
		}
		public ScoreTypes ScoreType;

		public Text ValueTextComponent;

		private void Update()
        {
			float currentValue = 0;
            /*
			switch (ScoreType)
            {
				case ScoreTypes.Money:
					currentValue = Model.Money;
					break;

				case ScoreTypes.Lives:
					currentValue = Model.Lives;
					break;
			}
            */
			ValueTextComponent.text = currentValue.ToString ();
		}
	}
}