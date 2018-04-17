using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.FlightControl
{
    [CreateAssetMenu]
	public class FlightControlModel : ScriptableObject, IModel
    {
		public float Speed;
		public float RotationSpeed;
	}
}