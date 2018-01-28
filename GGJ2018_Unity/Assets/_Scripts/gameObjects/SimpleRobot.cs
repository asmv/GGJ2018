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
		//add additional behavior exclusive to this enemy here
	}

	public override void collideProjectile(){
		throw new System.NotImplementedException ();
	}

	public override void destroyMe (){
		throw new System.NotImplementedException ();
	}

	// Use this for initialization
	void Start () {
		speed = INITSPEED;
		health = INITHEALTH;
		power = INITPOWER;
		kamikazeDamage = INITKAMIKAZEDAMAGE;
		bulletFireDelay = INITBULLTEFIREDELAY;

        this.placeAtCoordinates(new Vector2 (Random.Range(-9f, 9f), 5f));
	}
	
	// Update is called once per frame
	void Update () {
        this.move(Vector3.down);
        cullCheck();
	}
}
