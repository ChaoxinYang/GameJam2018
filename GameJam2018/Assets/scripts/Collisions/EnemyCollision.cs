using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {
	private HealthScript healthScript;

	public float enemyHealth = 10f;

	private ScoreKeeper scoreKeeper;

    private Animator shipAnimator;

    private GameObject CollRed;
    private GameObject CollOrange;
    private GameObject CollYellow;

    // Use this for initialization
    void Start () {
		healthScript = GameObject.Find("Health").GetComponent<HealthScript>();
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();

		CollRed = GameObject.Find("PS-Red");
		CollOrange = GameObject.Find("PS-Orange");
		CollYellow = GameObject.Find("PS-Yellow");
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyHealth <= 0){
			gameObject.SetActive(false);
			scoreKeeper.Score(50);
			Instantiate(CollRed, transform.position, Quaternion.identity);
			Instantiate(CollOrange, transform.position, Quaternion.identity);
			Instantiate(CollYellow, transform.position, Quaternion.identity);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		//gameObject.SetActive(false);
		if(coll.gameObject.CompareTag("Bullet")){
			enemyHealth -= 3;
		}else if(coll.gameObject.CompareTag("Rocket")){
			enemyHealth -= 10;
		}else if(coll.gameObject.CompareTag("PlayerShip")){
            shipAnimator = coll.gameObject.GetComponent<Animator>();
            shipAnimator.SetTrigger("takingDamage");
            healthScript.Damage(100);
			gameObject.SetActive(false);
			Instantiate(CollRed, transform.position, Quaternion.identity);
			Instantiate(CollOrange, transform.position, Quaternion.identity);
			Instantiate(CollYellow, transform.position, Quaternion.identity);
		}
	}
}
