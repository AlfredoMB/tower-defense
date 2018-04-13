using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using AlfredoMB.Ship;
using AlfredoMB.UI;

namespace AlfredoMB.Stage.Session {
	public class SessionView : View {
		public ScoreView Money;
		public ScoreView Lives;

		private SessionModel m_model;
		public SessionModel Model { 
			get {
				return m_model;
			}

			set {
				m_model = value;

				Money.Model = m_model;
				Lives.Model = m_model;
			}
		}
	}
}