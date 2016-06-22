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

	public void randomizeTiles() {

		for(int x = 0; x < width; x++) {
			for(int y = 0; y < height; y++) {

				if(Random.Range(0, 2) == 0) {

					tiles[x,y].Type = Tile.TileType.empty;
				} else {

					tiles[x,y].Type = Tile.TileType.floor;
				}
			}
		}
	}

	public Tile getTileAt(int x, int y) {

		return tiles[x,y];
	}

	public GameObject getGOat(int x, int y) {

		return GameObject.Find("tile_" + x + "_" + y);
	}
}
