using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{


    public enum EnemyType { Suicider };

    public EnemyType enemyType;
    [Header("Enemy attributes")]
    public float enemySpeed;
    public float range;

    GameObject playerShip;
    List<GameObject> targets = new List<GameObject>();
    GameObject target;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        playerShip = GameObject.FindGameObjectWithTag("PlayerShip");
        rb = GetComponent<Rigidbody2D>();

        foreach (GameObject t in GameObject.FindGameObjectsWithTag("Target")) targets.Add(t);

        SuiciderStateStart();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SuiciderState();
    }

    void SuiciderStateStart()
    {
        PickTarget();
        enemySpeed = 2f;
        range = 5f;
    }

    void SuiciderState()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerShip.transform.position);
        if (distanceToPlayer < range) target = playerShip;
        else if (Vector2.Distance(transform.position, target.transform.position) <= 1f) target = playerShip;  

        Vector2 enemyDir = target.transform.position - transform.position;
        enemyDir.Normalize();



        Quaternion enemyRotation = Quaternion.FromToRotation(Vector2.up, enemyDir);
        transform.rotation = enemyRotation;



        rb.velocity = enemyDir * enemySpeed;
    }

    void PickTarget()
    {
        target = targets[Random.Range(0, targets.Count)];
    }
}
