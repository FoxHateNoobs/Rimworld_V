using UnityEngine;
using System.Collections;
using System;

public class Tile {

	public enum TileType { ERROR, empty, floor }

	public int x { get; private set; }
	public int y { get; private set; }
	
	private TileType type = TileType.ERROR;

	private Action<Tile> typeChangeCB;

	public TileType Type {

		get {

			return type;
		}

		set {

			if(typeChangeCB != null && type != value) {

				type = value;
				typeChangeCB(this);
			}
		}
	}

	public void registerTypeChangedCB(Action<Tile> callback) {

		typeChangeCB += callback;
	}

	public Tile(int X, int Y) {

		x = X;
		y = Y;
	}
}
