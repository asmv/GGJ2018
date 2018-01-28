using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MoveableObject {

	public bool isShotByPlayer {get; set;}
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
		Debug.Log("BULLET SPEED: " + speed);
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection.x*speed, moveDirection.y*speed); //Test
	}

	public void OnBecameInvisible(){
		delete();
	}

	void FixedUpdate(){
		//this.GetComponent<Rigidbody2D>().velocity = moveDirection*speed; //Test
		Debug.Log("MD*s: " + moveDirection*speed);
		this.GetComponent<Rigidbody2D>().AddForce(moveDirection*speed, ForceMode2D.Force);
		//FIXME: temporary measure to catch all projectiles, when spawn bounds are correct, no  
		if(this.transform.localPosition.y < -8.0f){
			delete();
		}
	}

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
