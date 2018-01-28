using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRobot : PossessableEnemy {

	public float INITSPEED = 1;
	public int INITHEALTH = 100;
	public float INITPOWER = 10;
	public int INITKAMIKAZEDAMAGE = 30;
	public float INITBULLTEFIREDELAY = 0.5f;

	public Sprite explosionSprite;

	public Sprite[] sprites;

	public override void enterPlayerControl(){
		base.enterPlayerControl(); //call base class method of same name
		//add additional behavior exclusive to this enemy here
	}

	public override void leavePlayerControl(){
		base.leavePlayerControl(); //call base class method of same name
		StartCoroutine("doFirePattern");
		//add additional behavior exclusive to this enemy here
	}

	IEnumerator doFirePattern(){
		while(!this.isPlayerControlled){
			this.basicAttack();
			yield return new WaitForSeconds(this.bulletFireDelay);
		}
	}

	public override void collideProjectile(){
		Debug.Log("BOOM, SimpleRobot Destroyed");
		StartCoroutine("explodeAndDie");
	}

	public override void destroyMe (){
		StartCoroutine("explodeAndDie");
	}

	IEnumerator explodeAndDie(){
		//prevent further shot
		this.isReloading = true;
		this.GetComponent<SpriteRenderer>().sprite = explosionSprite;
		GameObject.Find("Game").GetComponent<SoundManager>().playExplosion();
		yield return new WaitForSeconds(0.3f);
		this.delete();
	}

	public override void move (Vector3 movementVector){
		//If we want to add additional AI, we can do so here, first add a variable "TimeAlive" and use that as input to a function that changes position
		base.move (movementVector);
	}

	// Use this for initialization
	void Start () {
		this.onStart();
		speed = INITSPEED;
		health = INITHEALTH;
		power = INITPOWER;
		kamikazeDamage = INITKAMIKAZEDAMAGE;
		bulletFireDelay = INITBULLTEFIREDELAY;
		StartCoroutine("doFirePattern");
	}
	
	// Update is called once per frame
	void Update () {
		if(!this.isPlayerControlled){
			this.move(Vector3.down);
		}
        cullCheck();
	}
}
