using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {
	private HealthScript healthScript;

	public float enemyHealth = 10f;

	private ScoreKeeper scoreKeeper;
    private Animator shipAnimator;

    // Use this for initialization
    void Start () {
		healthScript = GameObject.Find("Health").GetComponent<HealthScript>();
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyHealth <= 0){
			gameObject.SetActive(false);
			scoreKeeper.Score(50);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		//gameObject.SetActive(false);
		if(coll.gameObject.CompareTag("Bullet")){
			enemyHealth -= 5;
		}else{
            shipAnimator = coll.gameObject.GetComponent<Animator>();
            StartCoroutine("ShipShake");
            healthScript.Damage(100);
			gameObject.SetActive(false);
		}
	}

    IEnumerator ShipShake()
    {
        shipAnimator.SetBool("takingDamage", true);
        yield return new WaitForSeconds(12.0f);
        shipAnimator.SetBool("takingDamage", false);
    }
}
