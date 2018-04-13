using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Stage.Session
{
    [CreateAssetMenu]
	public class SessionModel : ScriptableObject, IModel
    {
		public int Money;
		public int Lives;
	}
}