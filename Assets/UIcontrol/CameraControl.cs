using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	void Update() {

		moveCamera();
	}

	void moveCamera() {

		float speedOfCamera = 0.2f;

		//Speed up
		if(Input.GetKey(KeyCode.LeftShift)) {

			speedOfCamera = 0.5f;
		}

		//Movements 
		if(Input.GetKey(KeyCode.W) && gameObject.transform.position.y < 91f) {

			gameObject.transform.Translate(0, speedOfCamera, 0);
		} else if(Input.GetKey(KeyCode.S) && gameObject.transform.position.y > 9f) {

			gameObject.transform.Translate(0, -speedOfCamera, 0);
		}

		if(Input.GetKey(KeyCode.A) && gameObject.transform.position.x > 17.5f) {

			gameObject.transform.Translate(-speedOfCamera, 0, 0);
		} else if(Input.GetKey(KeyCode.D) && gameObject.transform.position.x < 82.5f) {

			gameObject.transform.Translate(speedOfCamera, 0, 0);
		}
	}
}
