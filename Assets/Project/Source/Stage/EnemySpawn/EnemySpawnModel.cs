using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AlfredoMB.MVC;
using AlfredoMB.Ship;
using System;

namespace AlfredoMB.Stage.EnemySpawn {
	[CreateAssetMenu]
	public class EnemySpawnModel : Model {
		public List<SpawnModel> SpawnList;
	}

	[Serializable]
	public class SpawnModel {
		public float Time;
		public ShipController Ship;
	}
}