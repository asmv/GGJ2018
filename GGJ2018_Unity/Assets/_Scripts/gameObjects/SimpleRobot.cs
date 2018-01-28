using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRobot : PossessableEnemy {

	public float INITSPEED = 1;
	public int INITHEALTH = 100;
	public float INITPOWER = 10;
	public int INITKAMIKAZEDAMAGE = 30;
	public float INITBULLTEFIREDELAY = 0.5f;

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
		this.delete();
	}

	public override void destroyMe (){
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
