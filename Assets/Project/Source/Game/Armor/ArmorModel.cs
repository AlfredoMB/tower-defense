using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Armor
{
    [CreateAssetMenu]
	public class ArmorModel : ScriptableObject, IModel
    {
		public float HitPoints;
		public GameObject Explosion;
	}
}