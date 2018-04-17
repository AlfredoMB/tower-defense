using UnityEngine;
using AlfredoMB.MVC;
using UnityEngine.UI;
using AlfredoMB.DI;
using AlfredoMB.Stage;

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

        private IStageController _stage;

        private void Start()
        {
            _stage = SimpleDI.Get<IStageController>();
        }

        private void Update()
        {
			float currentValue = 0;
            
			switch (ScoreType)
            {
				case ScoreTypes.Money:
					currentValue = _stage.CurrentState.Money;
					break;

				case ScoreTypes.Lives:
					currentValue = _stage.CurrentState.Lives;
					break;
			}
			ValueTextComponent.text = currentValue.ToString ();
		}
	}
}