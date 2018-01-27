using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{


    public enum EnemyType { Suicider };

    public EnemyType enemyType;
    [Header("Enemy attributes")]
    public float enemySpeed;

    GameObject playerShip;
    GameObject target;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        playerShip = GameObject.FindGameObjectWithTag("PlayerShip");
        rb = GetComponent<Rigidbody2D>();

        SuiciderStateStart();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SuiciderState();
    }

    void SuiciderStateStart()
    {  
        enemySpeed = 2f;
    }

    void SuiciderState()
    {
        Vector2 enemyDir = playerShip.transform.position - transform.position;
        enemyDir.Normalize();
        Quaternion enemyRotation = Quaternion.FromToRotation(Vector2.up, enemyDir);
        transform.rotation = enemyRotation;

        rb.velocity = enemyDir * enemySpeed;
    }
}
