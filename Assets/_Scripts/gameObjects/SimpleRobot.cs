using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRobot : PossessableEnemy {

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

	public override void destroyMe ()
	{
		throw new System.NotImplementedException ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
