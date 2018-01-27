using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MoveableObject {

	public bool isShotByPlayer {get; protected set;}
	public float speed {get; protected set;}
	public float acceleration {get; protected set;}
	public float damage {get; protected set;}

	public Vector2 moveDirection {get; protected set;}

	public virtual void onHit(){
		//explosion/ player damage
	}

	public virtual void onFire(){
		//play sound effect
	}

	public virtual void setMovementDirection(Vector2 moveDirection){
		this.moveDirection = moveDirection;
		this.GetComponent<Rigidbody2D>().velocity = moveDirection*speed; //Test
	}

	void OnBecameInvisible(){
		delete();
	}

//	void FixedUpdate(){
//		this.GetComponent<Rigidbody2D>().velocity = moveDirection*speed; //Test
//	}

//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
}
