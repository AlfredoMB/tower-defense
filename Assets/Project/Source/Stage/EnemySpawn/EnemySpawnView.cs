using AlfredoMB.Game.Ship;
using AlfredoMB.MVC;
using AlfredoMB.PrefabPool;
using AlfredoMB.Ship;
using UnityEngine;

namespace AlfredoMB.Stage.EnemySpawn
{
    public class EnemySpawnView : MonoBehaviour, IView
    {
		public void Spawn(EnemySpawnModel.SpawnModel spawnModel, Transform destination)
        {
			ShipController newEnemy = PrefabPoolController.GetInstance(spawnModel.Ship.gameObject).GetComponent<ShipController>();
			newEnemy.transform.position = transform.position;
			newEnemy.MoveTo (destination.position);
		}
	}
}