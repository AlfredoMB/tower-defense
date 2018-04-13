using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;

namespace AlfredoMB.Ship {
	public class FlightControlView : View {
		private Rigidbody m_rigidBody; 

		public float DistanceFromEdges = 2f;

		private void Start() {
			m_rigidBody = GetComponent<Rigidbody> ();
		}

		public void MoveTo(Vector3 p_direction, bool p_limitedByScreen) {
			Vector3 newPosition = transform.position + p_direction * Time.deltaTime;

			if (p_limitedByScreen) {
				float cameraDistance = Camera.main.transform.position.y - transform.position.y;

				Vector3 topLeft = Camera.main.ScreenToWorldPoint (new Vector3 (0, Camera.main.pixelHeight, cameraDistance));
				Vector3 bottomRight = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth, 0, cameraDistance));

				newPosition.x = Mathf.Clamp (newPosition.x, topLeft.x + DistanceFromEdges, bottomRight.x - DistanceFromEdges);
				newPosition.z = Mathf.Clamp (newPosition.z, bottomRight.z + DistanceFromEdges, topLeft.z - DistanceFromEdges);
			}
			m_rigidBody.position = (newPosition);
		}
	}
}