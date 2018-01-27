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

	public virtual void move(Vector3 movementVector){
		this.transform.Translate(movementVector * this.speed * Time.deltaTime);
	}

	public virtual void transmitTo(){
		//play some animations indicating transmission
	}

	public virtual void basicAttack(){
		if(this.isReloading == false){
			this.isReloading = true;
			GameObject BulletGO = Instantiate(bulletPrefabRoot.Find(BULLETTYPE.simplebullet.ToString()).gameObject);
			if(this.isPlayerControlled){
				//fire bullet up
			}else{
				//fire bullet down or toward player
			}
			reload();
		}
	}

	IEnumerator reload(){
		yield return new WaitForSeconds(bulletFireDelay);
		this.isReloading = false;
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
