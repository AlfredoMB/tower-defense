using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Ship
{
    [CreateAssetMenu]
	public class ArmorModel : ScriptableObject, IModel
    {
		public float HitPoints;
		public GameObject Explosion;
	}
}