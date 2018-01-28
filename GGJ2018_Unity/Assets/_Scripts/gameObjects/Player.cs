using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	PossessableEnemy controlledEnemy;

	public int INITPLAYERHEALTH = 100;
	public int INITPLAYERTRANSMISSIONJUICE = 100;

	public int playerHealth;
	public int playerTransmissionJuice;

	private float playerControlledSpeedMultiplier = 3;

	public float transmissionDelay {get; protected set;}
	public bool isTransmitting {get; protected set;}

	public void setControlledEnemy(PossessableEnemy e){
		if(controlledEnemy!=null){
			controlledEnemy.leavePlayerControl();
		}
		e.gameObject.tag = "Player";
		this.controlledEnemy = e;
		e.speed=e.speed*playerControlledSpeedMultiplier;
		Debug.Log(playerControlledSpeedMultiplier);
		e.enterPlayerControl();
		this.transform.SetParent(controlledEnemy.transform);
		controlledEnemy.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 0.95f);
	}

	public void leaveControlledEnemy(){
		controlledEnemy.gameObject.tag = "Enemy";
		controlledEnemy.leavePlayerControl();
		controlledEnemy.speed/=playerControlledSpeedMultiplier;
		controlledEnemy.GetComponent<SpriteRenderer>().color = UnityEngine.Color.white;
	}

//	void OnCollisionEnter(Collision collision){
//		Debug.Log(collision.gameObject.tag);
//		if(collision.gameObject.tag == "Bullet"){
//			Debug.Log("PlayerHitByBullet");
//		}else if(collision.gameObject.tag == "Enemy"){
//			Debug.Log("PlayerHitByEnemy");
//		}
//	}

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
	void Awake () {
		this.playerHealth = INITPLAYERHEALTH;
		this.playerTransmissionJuice = INITPLAYERTRANSMISSIONJUICE;
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
					GameObject enemyObj = findClosest();
					PossessableEnemy e = enemyObj.GetComponent<PossessableEnemy>();
					if(e!=null){
						leaveControlledEnemy();
						setControlledEnemy(e);
						e.transmitTo();
					}else{
						//nothing to transmit to
						Debug.Log("Not Implemented Exception");
					}
					StartCoroutine("reloadTransmission");
				}
			}
		}
		
	}

	private GameObject findClosest(){
		var Gos = GameObject.FindGameObjectsWithTag("Enemy"); //FIXME: slight cheat, Enemy might not be possessable in future version
		GameObject closest = null;
		float distance = Mathf.Infinity;
		var position = this.transform.position;
		foreach(GameObject go in Gos){
			var curDistance = Vector3.Distance(position, go.transform.position);
			if(curDistance<distance){
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

	IEnumerator reloadTransmission(){
		yield return new WaitForSeconds(transmissionDelay);
		isTransmitting = false;
	}
}
