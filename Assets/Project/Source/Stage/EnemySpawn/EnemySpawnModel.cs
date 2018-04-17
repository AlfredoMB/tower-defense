using AlfredoMB.Game.Ship;
using AlfredoMB.MVC;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AlfredoMB.Stage.EnemySpawn
{
    [CreateAssetMenu]
	public class EnemySpawnModel : ScriptableObject, IModel
    {
        [Serializable]
	    public class SpawnModel
        {
		    public float Time;
		    public ShipController Ship;
	    }

		public List<SpawnModel> SpawnList;
	}	
}