using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData //Holds saveable data for player

{
    public int highScore;
    public int lastScore;
    public int totalCoins;

    public PlayerData(Player player)
    {
        lastScore = player.lastScore;

        highScore = player.highScore;

        totalCoins = player.totalCoins;
    }
}
