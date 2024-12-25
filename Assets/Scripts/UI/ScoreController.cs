using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

namespace InfinityJumper.Game
{
    public class ScoreController : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI highScoreText;
        public TextMeshProUGUI displayScore;
        private int highScore;
        private int score = 0;

        public void Awake()
        {
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }

        public void Update()
        {
            if(score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
        }
        public void IncreaseScore(int increment)
        {
            score += increment;
            RefreshUI();
        }
        private void RefreshUI()
        {
            scoreText.text = "Score : " + score;
            displayScore.text = "Your Score : " + score;
        }
    }
}

