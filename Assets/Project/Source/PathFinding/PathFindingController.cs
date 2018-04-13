using AlfredoMB.MVC;
using System.Collections.Generic;
using UnityEngine;

namespace AlfredoMB.Ship
{
    public class PathFindingController : MonoBehaviour, IController
    {
		public Transform Start;
		public Transform End;

		private void LateUpdate()
        {
			//Pathfinder.Instance.InsertInQueue(Start.transform.position, End.transform.position, CheckRoute);
		}

		private void CheckRoute(List<Vector3> list)
		{    
			/*
			//If we get a list that is empty there is no path, and we blocked the road
			//Then remove the last added tower!
			if (list.Count < 1 || list == null)
			{
				if (towers.Count > 0)
				{
					GameObject g = towers[towers.Count - 1];
					towers.RemoveAt(towers.Count - 1);
					Destroy(g);
				}
			}
			*/
		}
	}
}