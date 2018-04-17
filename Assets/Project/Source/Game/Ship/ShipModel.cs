using AlfredoMB.Game.Armor;
using AlfredoMB.Game.FlightControl;
using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Ship
{
    [CreateAssetMenu]
	public class ShipModel : ScriptableObject, IModel
    {
		public FlightControlModel FlightControl;
		public ArmorModel Armor;
		public int ScoreValue;
	}
}