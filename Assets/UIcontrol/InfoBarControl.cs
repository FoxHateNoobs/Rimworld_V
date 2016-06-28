using UnityEngine;
using System.Collections;

public class InfoBarControl : MonoBehaviour {

	private string title;
	
	void OnGUI() {

		GUI.Label(new Rect(10, 450, 400, 400), "" + title);
	}	

	public void showInfo(string title) {

		GetComponent<Renderer>().enabled = true;

		switch(title) {

			case "treePine":

			this.title = "Pine tree";
			break;
		}
	}

	public void closeInfoBar() {

		GetComponent<Renderer>().enabled = false;
		title = "";
	}


}
