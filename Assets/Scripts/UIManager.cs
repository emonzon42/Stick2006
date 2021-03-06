﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//changes onscreen UI
public class UIManager : MonoBehaviour
{
    public Player player;
    public Text score, coins;
    public GameObject gameOverUI, pauseMenuUI;
    public Button pauseButton;

    public static bool gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        GameOver(false);
        pauseButton.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (player.dead)
        {
            Time.timeScale = 0f;
            GameOver(true);
        }
        else
        {
            score.text = player.score.ToString();
            coins.text = player.numOfCoins.ToString();
        }

    }

    // (De)activates gameover ui
    void GameOver(bool b)
    {
        gameOverUI.SetActive(b);
        gameIsPaused = b;
        pauseButton.gameObject.SetActive(!b);
    }

   // Pauses game and brings up pause menu 
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        FindObjectOfType<AudioManager>().Pause("BG");
    }

    // Resumes game and removes pause menu 
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        pauseButton.gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().Play("BG");
    }

    // Restart scene from beginning
    public void Restart()
    {
        SceneManager.LoadScene("main");
    }

    // Quits back to main menu
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
