using UnityEngine;
using System.Collections;
using System;

public class Tile {

	public enum TileType { ERROR, empty, floor, dirt, grass }

	public int x { get; private set; }
	public int y { get; private set; }
	
	public InstalledObject installedObject;

	public Action<Tile> selectedCB;

	private TileType type = TileType.ERROR;

	private bool selected = false;

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

	public bool Selected {

		get {

			return selected;
		}

		set {

			if(typeChangeCB != null) {
			
			selected = value;
			selectedCB(this);							
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
