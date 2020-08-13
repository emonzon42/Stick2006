using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//changes onscreen UI
public class UIManager : MonoBehaviour
{
    [SerializeField] public Player player;
    public Text score, coins, loseText;
    public List<Button> buttons;

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

        for(int i = 0; i < buttons.Count; i++)
            buttons[i].gameObject.SetActive(b);
    }
}
