using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour {

    public float colorChangeSpeed = 10;
    public float sizeChangeSpeed = 0.15f;
    public float sizeChangeSize = 0.15f;
    public float rotationChangeSpeed = 0.15f;
    public float rotationChangeRotation = 45;
    float hue = 0;
    float gt = 0;
    float rt = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //the color changing
        hue += 0.01f * colorChangeSpeed * Time.deltaTime;
        if (hue >= 1) hue = 0;   
        GetComponent<Image>().color = Color.HSVToRGB(hue, 1, 1);

        //the resizing
        gt += sizeChangeSpeed;
        float amplitude = sizeChangeSize;
        transform.localScale = new Vector2((float)Mathf.Sin(gt) * amplitude + 2 ,(float)Mathf.Sin(gt) * amplitude + 2);

        //the rotating
        rt += rotationChangeSpeed;
        float rotAmplitude = rotationChangeRotation;
        transform.rotation = Quaternion.Euler(0f,0f, (float)Mathf.Sin(rt) * rotAmplitude);
    }
}
