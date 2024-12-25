using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace InfinityJumper.Game
{
    public class GameOverController : MonoBehaviour
    {
        public Button restartButton;
        public Button exitButton;

        public void Start()
        {
            restartButton.onClick.AddListener(RestartButtonClick);
            exitButton.onClick.AddListener(ExitButtonClick);
        }

        public void RestartButtonClick()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(0);
        }

        public void ExitButtonClick()
        {
            Application.Quit();
        }
    }
}

