using UnityEngine;
using System.Collections;

public class Cell {

	public Sprite empty_sp, floor_sp;

	enum CellType { ERROR, empty, floor }

	public CellType type { get; }
	
	public void setType(CellType newType, GameObject gameObject) {

		if(newType != type) {

			type = newType;

			switchTexture(gameObject);
		}
	}

	public int x { get; private set; }
	public int y { get; private set; }

	public Cell(int X, int Y) {

		x = X;
		y = Y;
		type = ERROR;
	}

	public void switchTexture(GameObject gameObject) {

		switch(type) {

			case empty:

				gameObject.GetComponent<SpriteRenderer>().sprite = empty_sp;
			break;

			case floor:

				gameObject.GetComponent<SpriteRenderer>().sprite = floor_sp;
			break;
		}
	}
}
