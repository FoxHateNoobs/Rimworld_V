using UnityEngine;
using System.Collections;

public class WorldControl : MonoBehaviour {

	public static WorldControl Instance { get; private set; }

	public Sprite empty_sp, floor_sp, dirt_sp, grass_sp, treePine, sBounds;

	public World world;

	void Start () {
		
		if(Instance == null) {

			Instance = this;
		}	

		world = new World(100, 100);
		createCellGOs();
	}

	void createCellGOs() {

		for(int x = 0; x < world.width; x++) {
			for(int y = 0; y < world.height; y++) {


				GameObject tile = new GameObject("tile_" + x + "_" + y);
				tile.transform.parent = GameObject.Find("WorldControl").transform;
				tile.transform.position = new Vector3(x, y, 0);
				tile.AddComponent<SpriteRenderer>();

				GameObject select = new GameObject("select_" + x + "_" + y);
				select.transform.parent = GameObject.Find("tile_" + x + "_" + y).transform;
				select.transform.position = new Vector3(x, y, -3);
				select.AddComponent<SpriteRenderer>();

				world.getTileAt(x, y).registerTypeChangedCB( (tile_data) => { changeSprite(tile, tile_data); });
				world.getTileAt(x, y).selectedCB += ( (tile_data) => { Select(select, tile_data); });
			}
		}

		world.randomTerrain();
		createTrees();
	}

	void createTrees() {

		for(int x = 0; x < world.width; x++) {
			for(int y = 0; y < world.height; y++) {

				if(world.getTileAt(x, y).Type == Tile.TileType.grass && Random.Range(0, 101) >= 70) {

					world.getTileAt(x, y).installedObject = new InstalledObject(x, y);

					GameObject tree = new GameObject("tree_" + x + "_" + y);
					tree.transform.parent = GameObject.Find("tile_" + x + "_" + y).transform;
					tree.transform.localScale = new Vector3(Random.Range(1f, 1.7f), Random.Range(1f, 1.7f), 1f);
					tree.transform.position = new Vector3(x, y + (tree.transform.localScale.y - 1f)/2, -1);
					tree.AddComponent<SpriteRenderer>();

					world.getTileAt(x, y).installedObject.registerObjectChangeCB( (object_data) => {changeObjectSprite(tree, object_data); });

					world.getTileAt(x, y).installedObject.iObject = InstalledObject.ObjectType.treePine;
				}
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

			case Tile.TileType.grass:
				go.GetComponent<SpriteRenderer>().sprite = grass_sp;
				break;

			case Tile.TileType.dirt:
				go.GetComponent<SpriteRenderer>().sprite = dirt_sp;
				break;

			default:
				Debug.Log("NO TYPE " + tile.x + " " + tile.y);
				break; 
		}
	}	

	void changeObjectSprite(GameObject go, InstalledObject iObject) {


		switch(iObject.iObject) {

			case InstalledObject.ObjectType.treePine:

				go.GetComponent<SpriteRenderer>().sprite = treePine;
			break;
		}
	}

	void Select(GameObject go, Tile tile) {

		if(tile.Selected) {

			go.GetComponent<SpriteRenderer>().sprite = sBounds; 
		} else {

			go.GetComponent<SpriteRenderer>().sprite = null;
		}
	}
}