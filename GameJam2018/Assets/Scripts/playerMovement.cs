using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public float rotPlayer1;
    public float rotPlayer2;
    public float rotationSpeed = 1f;
    GameObject player1, player2;

    private GameObject metalParticle;
    // Use this for initialization
    void Start () {
        player1 = transform.Find("player1").gameObject;
        player2 = transform.Find("player2").gameObject;

        rotPlayer1 = 0f;
        rotPlayer2 = 180f;

		metalParticle = GameObject.Find("MetalParticle");
	}

	void Update(){

		if (Input.GetKey(KeyCode.W)){

		player1.GetComponent<Weapon>().Fire();

		}
		if (Input.GetKey(KeyCode.UpArrow)){

		player2.GetComponent<Weapon>().Fire();

		}
	}


	// Update is called once per frame
	void FixedUpdate () {
        //player1 rotation
        if (Input.GetKey(KeyCode.A)){
        	rotPlayer1+= rotationSpeed;
			Instantiate(metalParticle, player1.transform.position, Quaternion.identity);
        }
        if (Input.GetKey(KeyCode.D)){
        	rotPlayer1-= rotationSpeed;
			Instantiate(metalParticle, player1.transform.position, Quaternion.identity);
        }
        rotPlayer1 = Mathf.Clamp(rotPlayer1, -90f, 90f);

        //player2 rotation
        if (Input.GetKey(KeyCode.LeftArrow)){
        	rotPlayer2 += rotationSpeed;
			Instantiate(metalParticle, player2.transform.position, Quaternion.identity);
        }
        if (Input.GetKey(KeyCode.RightArrow)){
        	rotPlayer2 -= rotationSpeed;
			Instantiate(metalParticle, player2.transform.position, Quaternion.identity);
        }
        rotPlayer2 = Mathf.Clamp(rotPlayer2, 90f, 270f);

        //changes the rotation and position of player1
        player1.transform.eulerAngles = new Vector3(0f, 0f, rotPlayer1);
        player1.transform.position = new Vector3(0f, 0f, 0f);
        player1.transform.Translate(new Vector3(-1.3f, 0f, 0f));

        //changes the rotation and position of player2
        player2.transform.eulerAngles = new Vector3(0f, 0f, rotPlayer2);
        player2.transform.position = new Vector3(0f, 0f, 0f);
        player2.transform.Translate(new Vector3(-1.3f, 0f, 0f));
    }
}
