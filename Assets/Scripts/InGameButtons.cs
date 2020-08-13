using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButtons : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene("main");
    }

    public void GotoStart()
    {
        SceneManager.LoadScene(0);
    }
}
