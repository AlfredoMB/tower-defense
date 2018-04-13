using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;

namespace AlfredoMB.Ship {
    public class PathFindingFlightControlView : View {
		public FlightControlModel Model { get; set; }
		
		private Pathfinding m_pathFinding;
		private Rigidbody m_rigidbody;

		private Vector3 m_targetPosition;


		private void Awake() {
			m_pathFinding = GetComponent<Pathfinding>();
			m_rigidbody = GetComponent<Rigidbody> ();
		}

		public void MoveTo(Vector3 p_position) {
			m_targetPosition = p_position;
		}

		private void Update() {
			m_pathFinding.FindPath(transform.position, m_targetPosition);

			float directionMagnitude = Model.Speed * Time.deltaTime;
			float pathTrackMagnitude = 0;
			Vector3 finalPosition = transform.position;

			foreach(Vector3 pathTrack in m_pathFinding.Path) {
				pathTrackMagnitude = pathTrack.magnitude;

				if (pathTrackMagnitude < directionMagnitude) {
					directionMagnitude -= pathTrackMagnitude;
					finalPosition += (pathTrack - finalPosition);
				} else {
					finalPosition += (pathTrack - finalPosition).normalized * directionMagnitude;
					break;
				}
			}

			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (finalPosition - transform.position), Time.deltaTime * Model.RotationSpeed);

			//transform.position = finalPosition;
			m_rigidbody.MovePosition (finalPosition);
        }
    }
}