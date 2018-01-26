using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public float rotPlayer1 = 90f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.A)) rotPlayer1++;
        if (Input.GetKey(KeyCode.D)) rotPlayer1--;
        
        transform.eulerAngles = new Vector3(0f, 0f, rotPlayer1);
        transform.position = new Vector3(0f, 0f, 0f);
        transform.Translate(new Vector3(-1.3f, 0f, 0f));
	}
}
