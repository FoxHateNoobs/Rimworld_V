using UnityEngine;
using System.Collections;
using System;

public class InstalledObject {

	public enum ObjectType {treePine} 

	public int x, y;

	private Action<InstalledObject> objectChangeCB;

	private ObjectType type;

	public ObjectType iObject {

		get {

			return type;
		}

		set {

			type = value;

			if(objectChangeCB != null) {

				objectChangeCB(this);	
			}
		}
	}

	public InstalledObject (int x, int y) {
		
		this.x = x;
		this.y = y;
	}

	public void registerObjectChangeCB(Action<InstalledObject> callback) {

		objectChangeCB += callback;
	}

}	
