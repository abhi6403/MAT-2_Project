using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    [SerializeField]
    private GameObject startMenu;
    [SerializeField] 
    private GameObject scoreText;

    public void Start()
    {
        startButton.onClick.AddListener(StartButtonClick);
        exitButton.onClick.AddListener(ExitButtonClick);
    }

    public void StartButtonClick()
    {
        Time.timeScale = 1.0f;
        scoreText.SetActive(true);
        startMenu.SetActive(false);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }
}