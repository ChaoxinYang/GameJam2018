using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Highscore : MonoBehaviour {
    public GameObject highscoreList, enterHighscore;
    private Text highscoreListText, enterHighscoreScore;

    void Start () {
        highscoreListText = highscoreList.transform.Find("Scores").GetComponent<Text>();
        enterHighscoreScore = enterHighscore.transform.Find("Score").GetComponent<Text>();
        highscoreListText.text = null;
        enterHighscoreScore.text = ScoreKeeper.score.ToString();
        UpdateHighscore();
        highscoreList.SetActive(false);
	}

    public void WriteHighscore()
    {
        int oldScore, newScore;
        string oldName, newName;
        newScore = ScoreKeeper.score;
        Debug.Log(newScore);
        newName = enterHighscore.transform.Find("PlayerOneInput").GetComponentInChildren<Text>().text + " & " + enterHighscore.transform.Find("PlayerTwoInput").GetComponentInChildren<Text>().text;
        Debug.Log("test2");
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey("HighscoreScore_" + i.ToString()))
            {
                if (PlayerPrefs.GetInt("HighscoreScore_" + i.ToString()) < newScore)
                {
                    oldScore = PlayerPrefs.GetInt("HighscoreScore_" + i.ToString());
                    oldName = PlayerPrefs.GetString("HighscoreName_" + i.ToString());
                    PlayerPrefs.SetInt("HighscoreScore_" + i.ToString(), newScore);
                    PlayerPrefs.SetString("HighscoreName_" + i.ToString(), newName);
                    newScore = oldScore;
                    newName = oldName;
                }
            }
            else
            {
                PlayerPrefs.SetInt("HighscoreScore_" + i.ToString(), newScore);
                PlayerPrefs.SetString("HighscoreName_" + i.ToString(), newName);
                newScore = 0;
                newName = "Player One & Player Two";
            }
        }
        PlayerPrefs.Save();
        UpdateHighscore();
        enterHighscore.SetActive(false);
        highscoreList.SetActive(true);
    }

    void UpdateHighscore()
    {
        for (int i = 0; i < 10; i++)
        {

            if (PlayerPrefs.HasKey("HighscoreScore_" + i.ToString()))
            {
                highscoreListText.text += i.ToString("00") + ". " + PlayerPrefs.GetInt("HighscoreScore_" + i.ToString()) + " " + PlayerPrefs.GetString("HighscoreName_" + i.ToString()) + "\n";
            }
            else
            {
                highscoreListText.text += i.ToString("00") + ". " + "\n";
            }
        }
    }
}
