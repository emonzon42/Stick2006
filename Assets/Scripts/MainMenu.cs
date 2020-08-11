using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public TextMeshProUGUI highScore, totalCoins, lastScore;

    public void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        highScore.text = "HI: " + data.highScore.ToString();
        totalCoins.text = "COINS: " + data.totalCoins.ToString();
        lastScore.text = "LAST: " + data.lastScore.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void QuitGame()
    {
        Debug.Log("Quit from main menu!");
        Application.Quit();
    }
}
