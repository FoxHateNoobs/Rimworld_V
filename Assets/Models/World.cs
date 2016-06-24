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

				int rand = Random.Range(0, 101);

				if(rand <= 5) {

					tiles[x,y].Type = Tile.TileType.floor;
				} else if(rand <= 25) {

					tiles[x,y].Type = Tile.TileType.grass;
				} else if(rand <= 100) {

					tiles[x,y].Type = Tile.TileType.dirt;
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
