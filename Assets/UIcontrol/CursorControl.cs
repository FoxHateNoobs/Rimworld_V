using UnityEngine;
using System.Collections;

public class CursorControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		UpdatePosition();
	}

	void UpdatePosition() {

		Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		newPosition.z = -1;

		gameObject.transform.position = newPosition;
	}
}
