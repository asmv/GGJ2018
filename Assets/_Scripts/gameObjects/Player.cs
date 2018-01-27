using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	PossessableEnemy controlledEnemy;

	public void setControlledEnemy(PossessableEnemy e){
		if(controlledEnemy!=null){
			controlledEnemy.leavePlayerControl();
		}
		this.controlledEnemy = e;
	}

///Just some code in case an int id is passed in, should not be required, and doesn't work yet anyway
//	public bool setControlledEnemy(int enemyId){
//		var p = FindObjectsOfType(PossessableEnemy) as PossessableEnemy[]; 
//		foreach(Enemy e in p){
//			if(e.objectId == enemyId){
//				this.controlledEnemy = e;
//				return true;
//			}
//		}
//		return false; //not found
//	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
