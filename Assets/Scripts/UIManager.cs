using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//changes onscreen UI
public class UIManager : MonoBehaviour
{
    [SerializeField] public PlayerData player;
    public Text score, coins, loseText;
    public Button restart;

    // Start is called before the first frame update
    void Start()
    {
        Activate(false);

    }
    // Update is called once per frame
    void Update()
    {
        if (player.dead)
            Activate(true);
        else
        {
            score.text = player.score.ToString();
            coins.text = player.numOfCoins.ToString();
        }

    }

    // (De)activates lose screen ui
    void Activate(bool b)
    {
        loseText.gameObject.SetActive(b);
        restart.gameObject.SetActive(b);
    }
}
