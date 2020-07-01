using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to hold all player data during game
public class PlayerData : MonoBehaviour
{

    public  bool isDead;
    public int score;
    public int numOfCoins;
    private Vector3 lastGroundPos;
    private bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        score = 0;
        numOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if (onGround)
            lastGroundPos = transform.position;

        if (transform.position.y < lastGroundPos.y - 10f)
            isDead = true;

        if (isDead)
            Application.isPlaying = false; //todo: change to die screen
        else
            score++;
    }

    void OnCollisionEnter2D(Collision2D obj)
    { 
        if (obj.gameObject.tag == "ground")
        {
            onGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "ground")
        {
            onGround = false;
        }
    }
}
