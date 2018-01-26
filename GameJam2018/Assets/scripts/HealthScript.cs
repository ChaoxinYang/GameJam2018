using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {
	public int health = 500;

	private Text myText;
	// Use this for initialization
	void Start () {
		myText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0){
			string currentScene = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(currentScene);
			ScoreKeeper.Reset();
		}
		if(Input.GetKeyDown(KeyCode.F)){
			Damage(100);
		}
	}

	public void Damage(int hitPoints){
		health -= hitPoints;
		myText.text = health.ToString();
	}
}
