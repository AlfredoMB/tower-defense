using UnityEngine;
using AlfredoMB.MVC;
using AlfredoMB.Tower.Turret;

namespace AlfredoMB.Tower
{
	[CreateAssetMenu]
	public class TowerModel : ScriptableObject, IModel
    {
		public TurretModel Turret;
		public int Cost;
		public string Name;
	}
}