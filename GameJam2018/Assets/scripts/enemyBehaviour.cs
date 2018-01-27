using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour {


    public enum EnemyType { Suicider };

    public EnemyType enemyType;
    [Header("Enemy attributes")]
    public float enemySpeed;
    public float enemyHealth;
    private GameObject playerShip;

    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        playerShip = GameObject.FindGameObjectWithTag("PlayerShip");
        rb = GetComponent<Rigidbody2D>();
        SuiciderStateStart();
    }
	
	// Update is called once per frame
	void Update () {
        SuiciderState();
	}

    void SuiciderStateStart()
    {
        enemySpeed = 2f;
        enemyHealth = 10f;
    }

    void SuiciderState()
    {
        Vector2 enemyDir = transform.position - playerShip.transform.position;
        Quaternion enemyRotation = Quaternion.FromToRotation(Vector2.up, enemyDir);
        transform.rotation = enemyRotation;
        enemyDir.Normalize();


        rb.velocity = -enemyDir * enemySpeed;
    }
}
