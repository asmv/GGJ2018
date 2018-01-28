using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PossessableEnemy : Enemy {

	public int transmissionDepletion{get; protected set;}
	public bool isPlayerControlled = false;

	public bool isInvincible = false;
	public static int INVINCIBILLITYSECONDS = 1;

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
		yield return new WaitForSeconds(bulletFireDelay);
		this.isReloading = false;
	}

	void OnTriggerEnter2D(Collider2D collision){
		Debug.Log("Trigger Collision Registered");
		if(this.isPlayerControlled){
			if(!this.isInvincible){
				Debug.Log("player-Controlled enemy collision: " + collision.gameObject.tag);
				GameObject PlayerGO = GameObject.Find("Player");
				if(collision.gameObject.tag == "Bullet"){
					Debug.Log("PlayerHitByBullet");
					PlayerGO.GetComponent<Player>().playerHealth-=collision.gameObject.GetComponent<Projectile>().damage;
				}
				if(collision.gameObject.tag == "Enemy"){
					Debug.Log("PlayerHitByEnemy");
					Enemy hitEnemy = collision.gameObject.GetComponent<Enemy>();
					PlayerGO.GetComponent<Player>().playerHealth-=hitEnemy.kamikazeDamage;
					hitEnemy.collidePlayer();
				}
				Debug.Log("PlayerHealth: " + PlayerGO.GetComponent<Player>().playerHealth);
				this.isInvincible = true;
				StartCoroutine("invincibilityFrames");
			}
		}else{
			if(collision.gameObject.tag == "Bullet" && collision.gameObject.GetComponent<Projectile>().isShotByPlayer){
				Debug.Log("EnemyHitByBullet");
				this.collideProjectile();
			}
		}
	}

	IEnumerator invincibilityFrames(){
		yield return new WaitForSeconds(INVINCIBILLITYSECONDS);
		this.isInvincible = false;
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
