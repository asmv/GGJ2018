using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MoveableObject {

	public float speed {get; protected set;}
	public int health {get; protected set;}
	public float power {get; protected set;}
	public int kamikazeDamage {get; protected set;}

	public abstract void collideProjectile();
	public virtual void collidePlayer(){
		destroyMe();
	}
	public abstract void destroyMe();

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
