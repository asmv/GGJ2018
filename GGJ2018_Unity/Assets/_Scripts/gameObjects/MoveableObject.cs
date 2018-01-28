using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveableObject : MonoBehaviour {

	public int objectId{get {return this.GetInstanceID();} }

	public bool isAlive{get; protected set;}
	public bool isOnscreen{get; protected set;}
	public bool killWhenOffscreen{get; protected set;}

	public virtual void onStart () {
		if(this.GetComponent<BoxCollider2D>() == null){
			Debug.Log("Warning, object " + this.gameObject.name + " does not have a BoxCollider2D component.");
		}
		this.GetComponent<Rigidbody2D>().freezeRotation = true;
	}

	public void placeAtCoordinates(Vector2 coordinates){
		Vector3 coords = new Vector3(coordinates.x, coordinates.y, 0);
		this.GetComponent<Transform>().localPosition = coords;
	}

	public Vector2 get2DCoordinates(){
		return this.GetComponent<Transform>().localPosition;
	}

	public void delete(){
		this.isAlive = false;
		Destroy(gameObject);
	}
}
