using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    public void Awake()
    {
        //scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void IncreaseScore(int increment)
    {
        score += increment;
        //scoreText.text = "Score : " + score;
        RefreshUI();
    }
    private void RefreshUI()
    {
        scoreText.text = "Score : " + score;
    }
}
