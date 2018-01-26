using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public float rotPlayer1 = 90f;
    public float rotationSpeed = 1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.A)) rotPlayer1+= rotationSpeed;
        if (Input.GetKey(KeyCode.D)) rotPlayer1-= rotationSpeed;

        rotPlayer1 = Mathf.Clamp(rotPlayer1, -90f, 90f);
        transform.eulerAngles = new Vector3(0f, 0f, rotPlayer1);
        transform.position = new Vector3(0f, 0f, 0f);
        transform.Translate(new Vector3(-1.3f, 0f, 0f));
	}
}
