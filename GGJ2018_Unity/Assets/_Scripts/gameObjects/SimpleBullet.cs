using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet {

	public float INITSPEED = 1;
	public int INITACCELERATION = 0;
	public int INITDAMAGE = 10;

	// Use this for initialization
	void Awake () {
		speed = INITSPEED;
		acceleration = INITACCELERATION;
		damage = INITDAMAGE;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
