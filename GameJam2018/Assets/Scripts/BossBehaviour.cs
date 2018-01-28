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

    void Start () {

        currentState = 0; 
        StartCoroutine(Moving());

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

  
}
