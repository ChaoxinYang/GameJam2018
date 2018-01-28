using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static int score;

    private Text myText;
    // Use this for initialization
    void Start()
    {
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Score(50);
        }
    }
    public void Score(int pointsGained)
    {
        score += pointsGained;
        myText.text = score.ToString();
    }

    public static void Reset()
    {
        score = 0;
    }
}