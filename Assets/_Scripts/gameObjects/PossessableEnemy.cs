using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PossessableEnemy : Enemy {

	public int transmissionDepletion{get; protected set;}
	public bool isPlayerControlled = false;

	public virtual void enterPlayerControl(){
		this.isPlayerControlled = true;
	}

	public virtual void leavePlayerControl(){
		this.isPlayerControlled = false;
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
