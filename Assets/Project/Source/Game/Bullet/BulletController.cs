using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Bullet
{
    public class BulletController : MonoBehaviour, IController
    {
		public BulletModel Model;

		private Rigidbody _rigidBody; 
		private Vector3 _direction;


		private void Start()
        {
			_rigidBody = GetComponent<Rigidbody> ();
		}

		public void FireTowards(Vector3 direction)
        {
			_direction = direction;
		}

		private void Update()
        {
			_rigidBody.MovePosition(transform.position + _direction * Time.deltaTime);

			float cameraDistance = Camera.main.transform.position.y - transform.position.y;

			Vector3 topLeft = Camera.main.ScreenToWorldPoint (new Vector3(0, Camera.main.pixelHeight, cameraDistance));
			Vector3 bottomRight = Camera.main.ScreenToWorldPoint (new Vector3(Camera.main.pixelWidth, 0, cameraDistance));

			if (transform.position.x < topLeft.x - 5f || transform.position.x > bottomRight.x + 5f || 
				transform.position.z < bottomRight.z - 5f || transform.position.z > topLeft.z + 5f	)
            {
				Destroy (gameObject);
			}
		}

	}
}