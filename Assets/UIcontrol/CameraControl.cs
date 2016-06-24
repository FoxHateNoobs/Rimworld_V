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
		
		UnpressingKeys();

		SmoothMovement();
	}

	void SmoothMovement() {

		//If TFSM = 0 then we stop moving.
		if(TFSM <= 0) {

			TFSM = 0;
			for(int i = 0; i < 4; i++) {

				speed[i] = 0;
			}
		} else {

			TFSM -= Time.deltaTime;

			for(int i = 0; i < 4; i++) {

				//Debug.Log(speed[i] + " " + i);
				//speed[i] /= 2;
			}
		}
	}

	void UnpressingKeys() {

		float defTFSM = 2f;

		//Check if keys were unpressed.
		if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) && !(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))) {

			TFSM = defTFSM;
			speed[2] = 0;
			speed[3] = 0;			
		} else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)) {

			Debug.Log("GG");
			speed[0] = 0;
			speed[1] = 0;
		}

		if(Input.GetKeyUp(KeyCode.D) || Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))) {

			TFSM = defTFSM;
			
			speed[0] = 0;
			speed[1] = 0;
		} else if(Input.GetKeyUp(KeyCode.D) || Input.GetKey(KeyCode.A)) {

			speed[2] = 0;
			speed[3] = 0;
		}
	}

	void Movements() {

		float speedOfCamera = 0.2f;

		//Speed up
		if(Input.GetKey(KeyCode.LeftShift)) {

			speedOfCamera = 0.5f;
		}

		//Movements 
		if(Input.GetKey(KeyCode.W) && gameObject.transform.position.y < 91f) {

			speed[0] = speedOfCamera;
			TFSM = 0f;
		} else if(Input.GetKey(KeyCode.S) && gameObject.transform.position.y > 9f) {

			speed[1] = speedOfCamera;
			TFSM = 0f;
		}

		if(Input.GetKey(KeyCode.A) && gameObject.transform.position.x > 15.5f) {

			speed[2] = speedOfCamera;
			TFSM = 0f;
		} else if(Input.GetKey(KeyCode.D) && gameObject.transform.position.x < 82.5f) {

			speed[3] = speedOfCamera;
			TFSM = 0f;
		}

		gameObject.transform.Translate(new Vector3(speed[3] - speed[2], speed[0] - speed[1], 0f));
	}
}
