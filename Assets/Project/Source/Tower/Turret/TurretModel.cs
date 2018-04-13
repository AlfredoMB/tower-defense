using UnityEngine;
using AlfredoMB.MVC;
using AlfredoMB.Ship;

namespace AlfredoMB.Tower.Turret
{
    [CreateAssetMenu]
	public class TurretModel : ScriptableObject, IModel
    {
		public CannonModel Cannon;
		public float TurnSpeed;
		public float ActionRadius;
	}
}