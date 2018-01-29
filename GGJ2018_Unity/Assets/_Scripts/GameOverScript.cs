using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	public void fadein(){
		this.gameObject.SetActive(true);
	}

	public void onClick(){
		this.gameObject.SetActive(false);
		SceneManager.LoadScene(0); //main menu
	}
}
