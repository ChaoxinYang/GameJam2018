using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Highscore : MonoBehaviour
{
    public GameObject highscoreList, enterHighscore;
    private Text highscoreListText, enterHighscoreScore;

    void Start()
    {
        highscoreListText = highscoreList.transform.Find("Scores").GetComponent<Text>();
        enterHighscoreScore = enterHighscore.transform.Find("Score").GetComponent<Text>();
        highscoreListText.text = null;
        enterHighscoreScore.text = ScoreKeeper.score.ToString();
        highscoreList.SetActive(false);
    }

    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
            highscoreListText.text = null;
            UpdateHighscore();
        }
    }
    */

    public void WriteHighscore()
    {
        int oldScore, newScore;
        string oldName, newName;
        newScore = ScoreKeeper.score;
        newName = enterHighscore.transform.Find("PlayerOneInput").GetComponentInChildren<Text>().text + " & " + enterHighscore.transform.Find("PlayerTwoInput").GetComponentInChildren<Text>().text;
        for (int i = 1; i < 11; i++)
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
                break;
            }
        }
        PlayerPrefs.Save();
        UpdateHighscore();
        highscoreList.SetActive(true);
        enterHighscore.SetActive(false);
    }

    public void CloseHighscore()
    {
        SceneManager.LoadScene("Start");
    }

    private void UpdateHighscore()
    {
        for (int i = 1; i < 11; i++)
        {
            highscoreListText.text += i.ToString("00") + ". " + PlayerPrefs.GetInt("HighscoreScore_" + i.ToString(), 0) + " " + PlayerPrefs.GetString("HighscoreName_" + i.ToString(), null) + "\n";
        }
    }
}
