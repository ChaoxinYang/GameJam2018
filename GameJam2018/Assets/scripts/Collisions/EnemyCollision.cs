using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {
	private HealthScript healthScript;
	// Use this for initialization
	void Start () {
		healthScript = GameObject.Find("Health").GetComponent<HealthScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		gameObject.SetActive(false);
		healthScript.Damage(100);
	}
}
