using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverPopup : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;
    
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void Show(int score, int bestScore)
    {
        gameObject.SetActive(true);

        scoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
    }

    public void OnpressedRestartButton()
    {
        GameController.Instance.OnRestartGame();
    }
   
}
