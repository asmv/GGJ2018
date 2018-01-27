using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone {

	public Vector3 location;
	public Vector2 size;

	public Vector2 getLocation(){
		return location;
	}

	public float getWidth(){
		return size.x;
	}

	public float getHeight(){
		return size.y;
	}
}
