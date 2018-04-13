using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AlfredoMB.MVC;

namespace AlfredoMB.Ship {
	[CreateAssetMenu]
	public class ArmorModel : Model {
		public float HitPoints;
		public GameObject Explosion;
	}
}