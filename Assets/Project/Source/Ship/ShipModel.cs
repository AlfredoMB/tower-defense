using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Ship
{
    [CreateAssetMenu]
	public class ShipModel : ScriptableObject, IModel
    {
		public FlightControlModel FlightControl;
		public ArmorModel Armor;
		public int ScoreValue;
	}
}