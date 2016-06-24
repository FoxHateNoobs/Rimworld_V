using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject cursor;

	float[] speed = new float[4];// UP DOWN LEFT RIGHT
	float TFSM = 0f;//time for smooth movement
	float defTFSM = 0.5f;
	float speedOfCamera = 0.5f;
	float defSpeedOfCamera = 0.5f;
	
	Vector3 prevPos = new Vector3(0f, 0f, 0f);

	void Update() {

		MovementsWithKeyBoard();
		MovementsWithMMB();
		MovementsOnBounds();

		SmoothMovement();

		gameObject.transform.Translate(new Vector3(speed[3] - speed[2], speed[0] - speed[1], 0f));
		normalizeCamera();
	}	

	//Check if camera went out of bounds
	void normalizeCamera() {

		Vector3 newPos = gameObject.transform.position;

		if(gameObject.transform.position.x > 82f) {

			newPos.x = 82f;
		} else if(gameObject.transform.position.x < 17f) {

			newPos.x = 17f;
		}

		if(gameObject.transform.position.y > 90f) {

			newPos.y = 90f;
		} else if(gameObject.transform.position.y < 9) {

			newPos.y = 9f;
		}

		gameObject.transform.position = newPos;
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

	void MovementsOnBounds() {

		float width = 17.3f;
		float height = 9.7f;

		//Movements 
		if(cursor.transform.localPosition.y < -height) {

			speed[1] = speedOfCamera;
			speed[0] = 0f;
			TFSM = defTFSM;
		} else if(cursor.transform.localPosition.y > height) {

			speed[0] = speedOfCamera;
			speed[1] = 0f;
			TFSM = defTFSM;
		} else if(cursor.transform.localPosition.x > width) {

			speed[3] = speedOfCamera;
			speed[2] = 0f;
			TFSM = defTFSM;
		} else if(cursor.transform.localPosition.x < -width) {

			speed[2] = speedOfCamera;
			speed[3] = 0f;
			TFSM = defTFSM;
		}
	}

	//MMB - middle mouse button.
	void MovementsWithMMB() {

		Vector3 curPos = Input.mousePosition;
		float dist = 0f;
		float speedModificator = 30;

		if(!Input.GetKey(KeyCode.Mouse2)) {

			prevPos = curPos;
			return;
		}

		if(curPos.x - prevPos.x < 0) {

			dist = (prevPos.x - curPos.x)/speedModificator;
			speed[3] = dist;
			speed[2] = 0f;
			TFSM = defTFSM;
		} else if(curPos.x - prevPos.x > 0) {
			
			dist = (curPos.x - prevPos.x)/speedModificator;
			speed[2] = dist;
			speed[3] = 0f;
			TFSM = defTFSM;
		}

		if(curPos.y - prevPos.y < 0) {

			dist = (prevPos.y - curPos.y)/speedModificator;
			speed[0] = dist;
			speed[1] = 0f;
			TFSM = defTFSM;
		} else if(curPos.y - prevPos.y > 0) {

			dist = (curPos.y - prevPos.y)/speedModificator;
			speed[1] = dist;
			speed[0] = 0f;
			TFSM = defTFSM;
		}

		prevPos = curPos;
	}

	void MovementsWithKeyBoard() {

		//Speed up
		if(Input.GetKey(KeyCode.LeftShift)) {

			speedOfCamera *= 1.5f;
		}

		//Movements 
		if(Input.GetKey(KeyCode.S)) {

			speed[1] = speedOfCamera;
			speed[0] = 0f;
			TFSM = defTFSM;
		} else if(Input.GetKey(KeyCode.W)) {

			speed[0] = speedOfCamera;
			speed[1] = 0f;
			TFSM = defTFSM;
		}

		if(Input.GetKey(KeyCode.D)) {

			speed[3] = speedOfCamera;
			speed[2] = 0f;
			TFSM = defTFSM;
		} else if(Input.GetKey(KeyCode.A)) {

			speed[2] = speedOfCamera;
			speed[3] = 0f;
			TFSM = defTFSM;
		}

		speedOfCamera = defSpeedOfCamera;
	}
}
