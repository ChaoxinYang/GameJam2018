using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public float rotPlayer1;
    public float rotPlayer2;
    public float rotationSpeed1, rotationSpeed2;
    GameObject player1, player2;
    AudioSource playerAudio;

    public float playerSpeed = 1.5f;

    private GameObject metalParticle;
    // Use this for initialization
    void Start () {
        player1 = transform.Find("player1").gameObject;
        player2 = transform.Find("player2").gameObject;

        rotPlayer1 = 0f;
        rotPlayer2 = 180f;

        rotationSpeed1 = 0f;
        rotationSpeed2 = 0f;

        playerAudio = gameObject.GetComponent<AudioSource>();

        metalParticle = GameObject.Find("MetalParticle");
	}

	void Update(){

        if (Input.GetKey(KeyCode.W))
        {
            player1.GetComponent<Weapon>().Fire();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player2.GetComponent<Weapon>().Fire();
        }
	}


	// Update is called once per frame
	void FixedUpdate () {
        //player1 rotation
        if (Input.GetKey(KeyCode.A))
        {
            rotationSpeed1 += 0.1f;
            rotPlayer1 += rotationSpeed1;
            PlaySound(playerAudio);
            Instantiate(metalParticle, player1.transform.position, Quaternion.identity);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotationSpeed1 += 0.1f;
            rotPlayer1 -= rotationSpeed1;
            PlaySound(playerAudio);
            Instantiate(metalParticle, player1.transform.position, Quaternion.identity);
        }
        else
        {
            rotationSpeed1 -= 0.25f * Mathf.Sign(rotationSpeed1);
        }
        rotPlayer1 = Mathf.Clamp(rotPlayer1, -90f, 90f);

		if (rotationSpeed1 > playerSpeed)
        {
			rotationSpeed1 = playerSpeed;
        }
		else if (rotationSpeed1 < -playerSpeed)
        {
			rotationSpeed1 = -playerSpeed;
        }

        //player2 rotation
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotationSpeed2 += 0.1f;
            rotPlayer2 += rotationSpeed2;
            PlaySound(playerAudio);
            Instantiate(metalParticle, player2.transform.position, Quaternion.identity);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotationSpeed2 += 0.1f;
            rotPlayer2 -= rotationSpeed2;
            PlaySound(playerAudio);
            Instantiate(metalParticle, player2.transform.position, Quaternion.identity);
        }
        else
        {
            rotationSpeed2 -= 0.25f * Mathf.Sign(rotationSpeed2);
        }

		if (rotationSpeed2 > playerSpeed)
        {
			rotationSpeed2 = playerSpeed;
        }
		else if (rotationSpeed2 < -playerSpeed)
        {
			rotationSpeed2 = -playerSpeed;
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) {

            playerAudio.Stop();
        }
        rotPlayer2 = Mathf.Clamp(rotPlayer2, 90f, 270f);

        //changes the rotation and position of player1
        player1.transform.eulerAngles = new Vector3(0f, 0f, rotPlayer1);
        player1.transform.position = new Vector3(0f, 0f, 0f);
        player1.transform.Translate(new Vector3(-2.6f, 0f, 0f));

        //changes the rotation and position of player2
        player2.transform.eulerAngles = new Vector3(0f, 0f, rotPlayer2);
        player2.transform.position = new Vector3(0f, 0f, 0f);
        player2.transform.Translate(new Vector3(-2.6f, 0f, 0f));
    }

    void PlaySound(AudioSource audioSource)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
