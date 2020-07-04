using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//changes onscreen UI
public class ScoreTracker : MonoBehaviour
{
    [SerializeField] public PlayerData player;
    public Text score;
    public Text coins;

    // Update is called once per frame
    void Update()
    {
        score.text = player.score.ToString();
        coins.text = player.numOfCoins.ToString();

    }
}
