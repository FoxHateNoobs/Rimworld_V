using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	float[] speed = new float[4];// UP DOWN LEFT RIGHT
	float TFSM = 0f;//time for smooth movement

	void Update() {

		moveCameraWithKeyboard();
	}

	void moveCameraWithMouse() {


	}

	void moveCameraWithKeyboard() {

		Movements();
		
		SmoothMovement();

		gameObject.transform.Translate(new Vector3(speed[3] - speed[2], speed[0] - speed[1], 0f));
	}

	void SmoothMovement() {

		//If TFSM = 0 then we stop moving.
		if(TFSM <= 0) {

			for(int i = 0; i < 4; i++) {

				speed[i] = 0;
			}
		} else {

			TFSM -= Time.deltaTime;

			for(int i = 0; i < 4; i++) {

				if(speed[i] > 0) 
					speed[i] *= 0.9f;
			}
		}
	}

	void Movements() {

		float speedOfCamera = 0.5f;
		float defTFSM = 0.5f;

		//Speed up
		if(Input.GetKey(KeyCode.LeftShift)) {

			speedOfCamera = speedOfCamera * 1.5f;
		}

		//Movements 
		if(Input.GetKey(KeyCode.S) && gameObject.transform.position.y > 9f) {

			speed[1] = speedOfCamera;
			speed[0] = 0f;
			TFSM = defTFSM;
		} else if(Input.GetKey(KeyCode.W) && gameObject.transform.position.y < 91f) {

			speed[0] = speedOfCamera;
			speed[1] = 0f;
			TFSM = defTFSM;
		}

		if(Input.GetKey(KeyCode.D) && gameObject.transform.position.x < 82.5f) {

			speed[3] = speedOfCamera;
			speed[2] = 0f;
			TFSM = defTFSM;
		} else if(Input.GetKey(KeyCode.A) && gameObject.transform.position.x > 15.5f) {

			speed[2] = speedOfCamera;
			speed[3] = 0f;
			TFSM = defTFSM;
		}
	}
}
