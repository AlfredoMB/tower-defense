using UnityEngine;
using System.Collections;
using AlfredoMB.MVC;

namespace AlfredoMB.Ship {
	public class BulletController : Controller {
		public BulletModel Model;

		private Rigidbody m_rigidBody; 
		private Vector3 m_direction;


		private void Start() {
			m_rigidBody = GetComponent<Rigidbody> ();
		}

		public void FireTowards(Vector3 p_direction) {
			m_direction = p_direction;
		}

		private void Update() {
			m_rigidBody.MovePosition(transform.position + m_direction * Time.deltaTime);

			float cameraDistance = Camera.main.transform.position.y - transform.position.y;

			Vector3 topLeft = Camera.main.ScreenToWorldPoint (new Vector3(0, Camera.main.pixelHeight, cameraDistance));
			Vector3 bottomRight = Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth, 0, cameraDistance));

			if (transform.position.x < topLeft.x - 5f || transform.position.x > bottomRight.x + 5f || 
				transform.position.z < bottomRight.z - 5f || transform.position.z > topLeft.z + 5f	) {
				Destroy (gameObject);
			}
		}

	}
}