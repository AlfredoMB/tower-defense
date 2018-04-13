using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using AlfredoMB.Ship;
using AlfredoMB.PrefabPool;

namespace AlfredoMB.Stage.EnemySpawn {
	public class EnemySpawnView : View {

		public void Spawn(SpawnModel p_spawnModel, Transform p_destination) {
			ShipController newEnemy = PrefabPoolController.GetInstance(p_spawnModel.Ship.gameObject).GetComponent<ShipController>();
			newEnemy.transform.position = transform.position;
			newEnemy.MoveTo (p_destination.position);
		}
	}
}