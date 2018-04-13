using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Ship
{
    [CreateAssetMenu]
	public class BulletModel : ScriptableObject, IModel
    {
		public float Damage;
		public float Mass;
	}
}