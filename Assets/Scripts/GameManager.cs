using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject loseUI;
    public int points = 0;
    public int record;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI recordText;

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    private void ShowLoseUI()
    {
        loseUI.SetActive(true);
    }

    public void RepeatGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void OnGameOver()
    {
        record = PlayerPrefs.GetInt("record", 0);
        if (points > record)
        {
            record = points;
            PlayerPrefs.SetInt("record", record);
        }
        
        recordText.text = $"Record: {PlayerPrefs.GetInt("record")}";
        ShowLoseUI();
        Time.timeScale = 0;
    }

    public void UpdateScore()
    {
        points++;
        scoreText.text = points.ToString();
    }
}
