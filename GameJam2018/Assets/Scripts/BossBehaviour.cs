using System;
using System.Collections;
using UnityEngine;

public class BossBehaviour : MonoBehaviour {
    public int health;
    public float speed;
    public Vector2[] target;
    public int currentState;
   // public GameObject spawn;
    public GameObject[] Shields;

    public float bossHealth = 200;

	private GameObject CollRed;
    private GameObject CollOrange;
    private GameObject CollYellow;

	private ScoreKeeper scoreKeeper;

	private Animator shipAnimator;

	private HealthScript healthScript;

    void Start () {

        currentState = 0; 
        StartCoroutine(Moving());

		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
		healthScript = GameObject.Find("Health").GetComponent<HealthScript>();

		CollRed = GameObject.Find("PS-Red");
		CollOrange = GameObject.Find("PS-Orange");
		CollYellow = GameObject.Find("PS-Yellow");
	}

    private IEnumerator Moving()
    {
        while (CheckIfDestinationReached(gameObject.transform.position, target[currentState])==false)
        {
            Debug.Log("lol");
            yield return new WaitForSeconds(0.1f);
           // gameObject.transform.Translate(speed * Time.deltaTime);
          transform.position=  Vector2.MoveTowards(gameObject.transform.position, target[currentState], speed * Time.deltaTime);
        }
           
        if (currentState > 0)
        {
            StartCoroutine(Spawning());
            
        }
        int[] rangeChoice = new int[] { 10 - currentState, -10 + currentState };
        Vector2 nextTarget = new Vector2( UnityEngine.Random.Range(rangeChoice[0],rangeChoice[1]), 10 - currentState);
        currentState++;
        target[currentState] = nextTarget;
        StartCoroutine(Moving());
        yield break;
    }



    private IEnumerator Spawning()
    {
        int mininonToSpawn = UnityEngine.Random.Range(currentState,currentState+3);

        for (int i = 0; i < mininonToSpawn; i++)
        {
            GameObject minion = ObjectPool.objectPool.GetPooledObjct("enemy1", true);
            minion.gameObject.GetComponent<EnemyCollision>().enemyHealth = 10f;
            minion.SetActive(true);
            minion.transform.position = transform.position;
        }
        yield break;

    }

    private bool CheckIfDestinationReached(Vector3 selfObject,Vector3 target)
    {
        bool reached = false;

        if (Vector3.Distance(selfObject, target) < 2 ) {

            reached = true;
        }

        return reached;
    }

    void Update(){
		if(bossHealth <= 0){
			gameObject.SetActive(false);
			scoreKeeper.Score(500);
			Instantiate(CollRed, transform.position, Quaternion.identity);
			Instantiate(CollOrange, transform.position, Quaternion.identity);
			Instantiate(CollYellow, transform.position, Quaternion.identity);
		}
    }
    /*
	void OnTriggerEnter2D(Collider2D coll){
    	if(coll.gameObject.CompareTag("Bullet")){
			bossHealth-= 1;
		}else if(coll.gameObject.CompareTag("Rocket")){
			bossHealth -= 10;
		}else{
            shipAnimator = coll.gameObject.GetComponent<Animator>();
            shipAnimator.SetTrigger("takingDamage");
            healthScript.Damage(200);
			gameObject.SetActive(false);
			Instantiate(CollRed, transform.position, Quaternion.identity);
			Instantiate(CollOrange, transform.position, Quaternion.identity);
			Instantiate(CollYellow, transform.position, Quaternion.identity);
		}
    }
    */

	void OnTriggerEnter2D(Collider2D coll){
		//gameObject.SetActive(false);
		if(coll.gameObject.CompareTag("Bullet")){
			bossHealth -= 1;
			Debug.Log("E:WKFJE:KLJF");
		}else if(coll.gameObject.CompareTag("Rocket")){
			bossHealth -= 10;
			Debug.Log("JF:L£KJ:LJ");
		}else if(coll.gameObject.CompareTag("PlayerShip")){
            shipAnimator = coll.gameObject.GetComponent<Animator>();
            shipAnimator.SetTrigger("takingDamage");
            healthScript.Damage(200);
			gameObject.SetActive(false);
			Instantiate(CollRed, transform.position, Quaternion.identity);
			Instantiate(CollOrange, transform.position, Quaternion.identity);
			Instantiate(CollYellow, transform.position, Quaternion.identity);
		}
	}

  
}
