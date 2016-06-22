using UnityEngine;
using System.Collections;

public class WorldControl : MonoBehaviour {

	public Sprite empty_sp, floor_sp;

	World world;

	float t = 1f;

	void Start () {
	
		world = new World(10, 10);
		createCellGOs();
		world.randomizeTiles();
	}

	void Update() {

		t -= Time.deltaTime;

		if(t < 0) {

			t = 1f;

			createCellGOs();
			world.randomizeTiles();
		}
	}

	void createCellGOs() {

		for(int x = 0; x < world.width; x++) {
			for(int y = 0; y < world.height; y++) {


				GameObject tile = new GameObject("tile_" + x + "_" + y);
				tile.transform.position = new Vector3(x, y, 0);
				tile.AddComponent<SpriteRenderer>();

				world.getTileAt(x, y).registerTypeChangedCB( (tile_data) => { changeSprite(tile, tile_data); });
			}
		}
	}

	void changeSprite(GameObject go, Tile tile) {


		switch(tile.Type) {

			case Tile.TileType.empty:
				go.GetComponent<SpriteRenderer>().sprite = empty_sp;
				break;

			case Tile.TileType.floor:
				go.GetComponent<SpriteRenderer>().sprite = floor_sp;
				break;

			default:
				Debug.Log("NO TYPE " + tile.x + " " + tile.y);
				break; 
		}
	}
}