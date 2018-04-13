using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Ship
{
    [CreateAssetMenu]
	public class FlightControlModel : ScriptableObject, IModel
    {
		public float Speed;
		public float RotationSpeed;
	}
}