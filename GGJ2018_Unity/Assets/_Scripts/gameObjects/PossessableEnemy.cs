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
		Debug.Log("Basic Attack from Possessable Enemy");
		if(this.isReloading == false){
			this.isReloading = true;
			GameObject BulletGO = Instantiate(bulletPrefabRoot.Find(BULLETTYPE.simplebullet.ToString()).gameObject);
			Bullet b = BulletGO.GetComponent<Bullet>();
			b.placeAtCoordinates(this.transform.localPosition);
			if(this.isPlayerControlled){
				b.isShotByPlayer = true;
				b.setMovementDirection(Vector2.up);
				//fire bullet up
			}else{
				b.isShotByPlayer = false;
				b.setMovementDirection(Vector2.down);
				//fire bullet down or toward player
			}
			StartCoroutine("reload");
		}
	}

	IEnumerator reload(){
		Debug.Log("In reload.");
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
