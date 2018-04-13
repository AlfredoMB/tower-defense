using UnityEngine;
using AlfredoMB.MVC;
using AlfredoMB.Stage.EnemySpawn;

namespace AlfredoMB.Stage
{
    [CreateAssetMenu]
	public class StageModel : ScriptableObject, IModel
    {
		public EnemySpawnModel EnemySpawn;

		public int StartingLives;
		public int StartingMoney;
	}
}