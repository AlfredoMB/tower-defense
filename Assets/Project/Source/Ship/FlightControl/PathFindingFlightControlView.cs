using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Ship
{
    public class PathFindingFlightControlView : MonoBehaviour, IView
    {
		public FlightControlModel Model { get; set; }
		
		private Pathfinding _pathFinding;
		private Rigidbody _rigidbody;

		private Vector3 m_targetPosition;


		private void Awake()
        {
			_pathFinding = GetComponent<Pathfinding>();
			_rigidbody = GetComponent<Rigidbody> ();
		}

		public void MoveTo(Vector3 position)
        {
			m_targetPosition = position;
		}

		private void Update()
        {
			_pathFinding.FindPath(transform.position, m_targetPosition);

			float directionMagnitude = Model.Speed * Time.deltaTime;
			float pathTrackMagnitude = 0;
			Vector3 finalPosition = transform.position;

			foreach(Vector3 pathTrack in _pathFinding.Path)
            {
				pathTrackMagnitude = pathTrack.magnitude;

				if (pathTrackMagnitude < directionMagnitude)
                {
					directionMagnitude -= pathTrackMagnitude;
					finalPosition += (pathTrack - finalPosition);
				}
                else
                {
					finalPosition += (pathTrack - finalPosition).normalized * directionMagnitude;
					break;
				}
			}

			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (finalPosition - transform.position), Time.deltaTime * Model.RotationSpeed);

			//transform.position = finalPosition;
			_rigidbody.MovePosition (finalPosition);
        }
    }
}