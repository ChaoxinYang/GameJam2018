using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{


    public enum EnemyType { Suicider , AttackShip};

    public EnemyType enemyType;
    [Header("Enemy attributes")]
    public float enemySpeed;
    public float range;
    public float shootingSpeed;

    public GameObject enemyBullet;

    float timer = 0;

    GameObject playerShip;
    GameObject target;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        playerShip = GameObject.FindGameObjectWithTag("PlayerShip");
        rb = GetComponent<Rigidbody2D>();

        if (enemyType == EnemyType.Suicider) SuiciderStateStart();
        else if (enemyType == EnemyType.AttackShip) AttackShipStateStart();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyType == EnemyType.Suicider) SuiciderState();
        else if (enemyType == EnemyType.AttackShip) AttackShipState();
    }

    void AttackShipStateStart()
    {
        enemySpeed = 2;
        range = 8;
        shootingSpeed = 5;
    }
    void SuiciderStateStart()
    {
        enemySpeed = 2;
    }

    void SuiciderState()
    {
        Vector2 enemyDir = playerShip.transform.position - transform.position;
        enemyDir.Normalize();
        Quaternion enemyRotation = Quaternion.FromToRotation(Vector2.up, enemyDir);
        transform.rotation = enemyRotation;

        rb.velocity = enemyDir * enemySpeed;
    }

    void AttackShipState()
    {
        if(Vector2.Distance(playerShip.transform.position, transform.position) > range)
        {
            Vector2 enemyDir = playerShip.transform.position - transform.position;
            enemyDir.Normalize();
            Quaternion enemyRotation = Quaternion.FromToRotation(Vector2.up, enemyDir);
            transform.rotation = enemyRotation;

            rb.velocity = enemyDir * enemySpeed;
        } else
        {
            rb.velocity = Vector2.zero;
            transform.RotateAround(playerShip.transform.position, Vector3.forward, enemySpeed /4);

            timer += Time.deltaTime;
            if(timer >= 5)
            {
                Instantiate(enemyBullet, transform.position, Quaternion.FromToRotation(this.transform.position, playerShip.transform.position));
                timer = 0;
            }
        }

        
    }
}
