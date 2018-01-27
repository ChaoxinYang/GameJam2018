using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {
	private ScoreKeeper scoreKeeper;

	public float timer = 5;
	// Use this for initialization
	void Start () {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if(timer <= 0){
			gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
	if(coll.gameObject.CompareTag("Enemy")){
			gameObject.SetActive(false);
		}

	}
}
