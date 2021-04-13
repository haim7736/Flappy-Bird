using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private static GameController _instance;

    public static GameController Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
            }
            return _instance;
        }
    }

    public SpikeManager spikeManager;
    public GameOverPopup gameOverPopup;
    public UIController uiController;

    private int _curScore;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        Time.timeScale = 1f;

        spikeManager.Init();
        uiController.Init();

        _curScore = 0;
        uiController.UpdateScore(_curScore);

    }

    internal void OnRestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void OnGameOver()
    {
        Time.timeScale = 0f;
        gameOverPopup.Show(_curScore, GetAndRecordBestScore(_curScore));

    }

    public void AddScore(int addingScore)
    {
        _curScore += addingScore;
        uiController.UpdateScore(_curScore);
    }

    private int GetAndRecordBestScore(int score)
    {
        var bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if(score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        return bestScore;
    }
}
