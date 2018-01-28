using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	PossessableEnemy controlledEnemy;

	public int playerHealth;
	public int playerTransmissionJuice;

	private float playerControlledSpeedMultiplier = 3;

	public float transmissionDelay {get; protected set;}
	public bool isTransmitting {get; protected set;}

	public void setControlledEnemy(PossessableEnemy e){
		if(controlledEnemy!=null){
			controlledEnemy.leavePlayerControl();
		}
		this.controlledEnemy = e;
		e.speed=e.speed*playerControlledSpeedMultiplier;
		Debug.Log(playerControlledSpeedMultiplier);
		e.enterPlayerControl();
		this.transform.SetParent(controlledEnemy.transform);
		controlledEnemy.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.95f);
	}

	public void leaveControlledEnemy(){
		controlledEnemy.leavePlayerControl();
		controlledEnemy.speed/=playerControlledSpeedMultiplier;
		controlledEnemy.GetComponent<SpriteRenderer>().color = UnityEngine.Color.white;
	}

	void OnCollisionEnter(Collider collision){

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
			if(Input.GetKey(KeyCode.Z)){
				controlledEnemy.basicAttack();
			}
			if(Input.GetKeyDown(KeyCode.X)){
				if(!isTransmitting){
					isTransmitting = true;
					//TODO: Find enemy to transmit to
					Debug.Log("Warning, transmission is not yet implemented.");
					PossessableEnemy e = null; //closest
					if(e!=null){
						leaveControlledEnemy();
						setControlledEnemy(e);
						e.transmitTo();
						throw new System.NotImplementedException();
					}
					StartCoroutine("reloadTransmission");
				}
			}
		}
		
	}

	IEnumerator reloadTransmission(){
		yield return new WaitForSeconds(transmissionDelay);
		isTransmitting = false;
	}
}
