using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject playerGO;
	private Player player;
	public Text healthValue;
	public Text transmissionValue;

	public void LoadByIndex(int sceneIndex){
        SceneManager.LoadScene (sceneIndex);
    }

	public void Quit(){
	#if UNITY_EDITOR
	        UnityEditor.EditorApplication.isPlaying = false;
	#else
	        Application.Quit ();
	#endif
    }

    void Start(){
    	player = playerGO.GetComponent<Player>();
    }

    void Update(){
    	updatePlayerValues();
    }

    void updatePlayerValues(){
    	this.healthValue.text = player.playerHealth.ToString();
    	this.transmissionValue.text = player.playerTransmissionJuice.ToString();
    }

}
