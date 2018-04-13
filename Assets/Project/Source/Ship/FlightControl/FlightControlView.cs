using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Ship
{
    public class FlightControlView : MonoBehaviour, IView
    {
		private Rigidbody _rigidBody; 

		public float DistanceFromEdges = 2f;

		private void Start()
        {
			_rigidBody = GetComponent<Rigidbody> ();
		}

		public void MoveTo(Vector3 direction, bool limitedByScreen)
        {
			Vector3 newPosition = transform.position + direction * Time.deltaTime;

			if (limitedByScreen)
            {
				float cameraDistance = Camera.main.transform.position.y - transform.position.y;

				Vector3 topLeft = Camera.main.ScreenToWorldPoint (new Vector3 (0, Camera.main.pixelHeight, cameraDistance));
				Vector3 bottomRight = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth, 0, cameraDistance));

				newPosition.x = Mathf.Clamp (newPosition.x, topLeft.x + DistanceFromEdges, bottomRight.x - DistanceFromEdges);
				newPosition.z = Mathf.Clamp (newPosition.z, bottomRight.z + DistanceFromEdges, topLeft.z - DistanceFromEdges);
			}
			_rigidBody.position = (newPosition);
		}
	}
}