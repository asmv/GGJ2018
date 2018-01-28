using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MoveableObject {

	public Transform bulletPrefabRoot;

	public float speed {get; set;}
	public int health {get; protected set;}
	public float power {get; protected set;}
	public int kamikazeDamage {get; protected set;}
	public float bulletFireDelay {get; protected set;}

	public abstract void collideProjectile();
	public virtual void collidePlayer(){
		destroyMe();
	}
	public abstract void destroyMe();

	public bool isReloading {get; protected set;}

//	void OnTriggerEnter2D(Collider2D other){
//		Debug.Log(other);
//		//TODO: need to do something here
////		if(other.CompareTag("Bullet")){
////
////		}else if 
//	}

    public void cullCheck(){
        if (transform.localPosition.y < -6f)
        {
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
