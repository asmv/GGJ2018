using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MoveableObject {

	public bool isShotByPlayer {get; protected set;}
	public float speed {get; protected set;}
	public float acceleration {get; protected set;}
	public float damage {get; protected set;}

	public virtual void onHit(){

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
