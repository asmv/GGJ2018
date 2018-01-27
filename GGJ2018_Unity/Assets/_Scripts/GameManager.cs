using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//singleton class
	public static GameManager instance;
	void Awake () {
		if(instance == null){
			instance = this;
		}
	}
	
	void Update () {
		
	}
}
