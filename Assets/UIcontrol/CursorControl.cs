using UnityEngine;
using System.Collections;

public class CursorControl : MonoBehaviour {

	public GameObject InfoBar;

	private string tileType = "";

	private Vector3 pos;

	private Tile tile;

	// Update is called once per frame
	void Update () {
		
		pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		UpdatePosition();
		GetInfoAboutTile();
		SelectObject();
	}

	void UpdatePosition() {

		pos.z = -2;

		gameObject.transform.position = pos;
	}

	void SelectObject() {

		tile = WorldControl.Instance.world.getTileAt((int) (pos.x + 0.5f), (int) (pos.y + 0.5f));

		if(Input.GetKeyDown(KeyCode.Mouse0) && tile.installedObject != null) {

			 UnselectOthers();
			 tile.Selected = true;
			 InfoBar.GetComponent<InfoBarControl>().showInfo("" + tile.installedObject.iObject);
		} else if(Input.GetKeyDown(KeyCode.Mouse0)) {

			UnselectOthers();
			InfoBar.GetComponent<InfoBarControl>().closeInfoBar();
		}
 	}

 	void UnselectOthers() {

 		tile = WorldControl.Instance.world.getTileAt((int) (pos.x + 0.5f), (int) (pos.y + 0.5f));

 		for(int x = 0; x < WorldControl.Instance.world.width; x++) {
 			for(int y = 0; y < WorldControl.Instance.world.height; y++) {

 				WorldControl.Instance.world.getTileAt(x, y).Selected = false;
 			}
 		}
 	}

	void GetInfoAboutTile() {

		tile = WorldControl.Instance.world.getTileAt((int) (pos.x + 0.5f), (int) (pos.y + 0.5f));

		switch(tile.Type) {

			case Tile.TileType.dirt:

				tileType = "Dirt";
			break;

			case Tile.TileType.grass:

				tileType = "Grass";
			break;
		}
	}

	void OnGUI() {

		GUI.Label ( new Rect (5, 5, 100, 100), "" + tileType);
	}
}
