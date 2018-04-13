using AlfredoMB.MVC;
using AlfredoMB.UI;
using UnityEngine;

namespace AlfredoMB.Stage.Session
{
    public class SessionView : MonoBehaviour, IView
    {
		public ScoreView Money;
		public ScoreView Lives;

		private SessionModel _model;
		public SessionModel Model
        { 
			get
            {
				return _model;
			}

			set
            {
				_model = value;

				Money.Model = _model;
				Lives.Model = _model;
			}
		}
	}
}