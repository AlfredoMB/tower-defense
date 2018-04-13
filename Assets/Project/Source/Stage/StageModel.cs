using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AlfredoMB.MVC;
using System;
using AlfredoMB.Stage.EnemySpawn;
using AlfredoMB.Ship;

namespace AlfredoMB.Stage {
	[CreateAssetMenu]
	public class StageModel : Model {
		public EnemySpawnModel EnemySpawn;

		public int StartingLives;
		public int StartingMoney;
	}
}