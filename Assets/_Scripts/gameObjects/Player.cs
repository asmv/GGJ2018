using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	PossessableEnemy controlledEnemy;

	public float transmissionDelay {get; protected set;}
	public bool isTransmitting {get; protected set;}

	public void setControlledEnemy(PossessableEnemy e){
		if(controlledEnemy!=null){
			controlledEnemy.leavePlayerControl();
		}
		this.controlledEnemy = e;
		e.enterPlayerControl();
		this.transform.SetParent(controlledEnemy.transform); //test thoroughly
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
		if(controlledEnemy!=null){
			Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			controlledEnemy.move(move);
			if(Input.GetKeyDown(KeyCode.Z)){
				controlledEnemy.basicAttack();
			}
			if(Input.GetKeyDown(KeyCode.X)){
				if(!isTransmitting){
					isTransmitting = true;
					//TODO: Find enemy to transmit to
					Debug.Log("Warning, transmission is not yet implemented.");
					PossessableEnemy e = null; //closest
					if(e!=null){
						controlledEnemy.leavePlayerControl();
						setControlledEnemy(e);
						e.transmitTo();
						throw new System.NotImplementedException();
					}
				}
			}
		}
		
	}

	IEnumerator reloadTransmission(){
		yield return new WaitForSeconds(transmissionDelay);
		isTransmitting = false;
	}
}
