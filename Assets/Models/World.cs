using UnityEngine;
using System.Collections;

public class World {

	public int width  { get; private set; }
	public int height { get; private set; }

	private Tile[,] tiles;

	public World(int width, int height) {

		this.width = width;
		this.height = height;

		createTiles();
	}

	public void createTiles() {

		tiles = new Tile[width, height];

		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {
				
				tiles[x,y] = new Tile(x, y);
			}
		}
	}	

	public void randomTerrain() {

		//Filling everything with grass
		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {

				tiles[x,y].Type = Tile.TileType.grass;
			}
		}

		for(int i = 0; i < 8; i++) {

			createDirt();
		}
	}

	public Tile getTileAt(int x, int y) {

		if(x < 0 || y < 0 || x >= width || y >= height) {

			return null;
		}

		return tiles[x,y];
	}

	public GameObject getGOat(int x, int y) {

		if(x < 0 || y < 0 || x >= width || y >= height) {

			return null;
		}

		return GameObject.Find("tile_" + x + "_" + y);
	}


	void createDirt() {

		int size = Random.Range(10, 40);
		int minX = Random.Range(width/10, width - width/10);
		int minY = Random.Range(height/10, height - height/10);

		int modificator = Random.Range(0, 2);

		for(int i = 1; i < 10; i++) {

			int X, Y;
			float _size = size;

			if(modificator == 0) {

				X = Random.Range(minX, minX + size);
				Y = Random.Range(minY + size/4, minY + size/2 + size/4);
			} else {

				X = Random.Range(minX + size/4, minX + size/2 + size/4);
				Y = Random.Range(minY, minY + size);
			}

			for(int x = X; x <= minX + size; x++) {
				for(int y = Y; y <= minY + size; y++) {

					if(getTileAt(x, y) == null) {

						continue;
					}

					//Getting vector from the center to random point
					Vector2 vec = new Vector2(Mathf.Abs(minX + size - size/2 - x), Mathf.Abs(minY + size - size/2 - y));

					//Computing chance of creating tile.
					float chance = 100 - vec.magnitude / (_size / 100);

					if(y == Y || y == minY + size || x == X || x == minX + size) {

						chance -= Random.Range(0, chance - 50);
					}

					if(chance >= 70) {

						tiles[x,y].Type = Tile.TileType.dirt;
					}
				}
			}
		}
	}
}
