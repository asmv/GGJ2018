using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource audioS;

	public AudioClip bulletShotAudio;
	public AudioClip transmitAudio;
	public AudioClip tookDamageAudio;
	public AudioClip explosionAudio;
	public AudioClip gameOverAudio;
	public AudioClip buttonsAudio;
	public 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playExplosion(){
		audioS.PlayOneShot(explosionAudio);
	}

	public void playTransmit(){
		audioS.PlayOneShot(transmitAudio);
	}

	public void playShot(){
		audioS.PlayOneShot(bulletShotAudio);
	}

	public void playDamaged(){
		audioS.PlayOneShot(tookDamageAudio);
	}

	public void playGameOver(){
		audioS.PlayOneShot(gameOverAudio);
	}

	public void playButtonSounds(){
		audioS.PlayOneShot(buttonsAudio);
	}
}
