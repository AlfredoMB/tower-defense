using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;
using AlfredoMB.PrefabPool;

namespace AlfredoMB.Ship {
	public class ShipView : View {	
		public float DistanceFromEdges = 50f;
			
		private void Update() {
			float cameraDistance = Camera.main.transform.position.y - transform.position.y;

			Vector3 topLeft = Camera.main.ScreenToWorldPoint (new Vector3 (0, Camera.main.pixelHeight, cameraDistance));
			Vector3 bottomRight = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth, 0, cameraDistance));

			if (transform.position.z < bottomRight.z - DistanceFromEdges ||
				transform.position.z > topLeft.z + DistanceFromEdges ||
			    transform.position.x < topLeft.x - DistanceFromEdges ||
			    transform.position.x > bottomRight.x + DistanceFromEdges) {
			
				PrefabPoolController.ReturnInstance (gameObject);
			}
		
		}
	}
}