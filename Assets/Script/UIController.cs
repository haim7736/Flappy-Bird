using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    public void Init()
    {

    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
