using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {
	public float maxHealth = 500;
	public float currenthealth;

	public Slider healthBar;

	private Text myText;
	// Use this for initialization
	void Start () {
		currenthealth = maxHealth;
		myText = GetComponent<Text>();

		healthBar.value = calculateHealth();
	}
	
	// Update is called once per frame
	void Update () {
		if(currenthealth <= 0){
			string currentScene = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(currentScene);
			ScoreKeeper.Reset();
		}
		if(Input.GetKeyDown(KeyCode.F)){
			Damage(100);
		}
	}

	float calculateHealth(){
		return currenthealth / maxHealth;
	}

	public void Damage(int hitPoints){
		currenthealth -= hitPoints;
		myText.text = currenthealth.ToString();
		healthBar.value = calculateHealth();
	}
}
