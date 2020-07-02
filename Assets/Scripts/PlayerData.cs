using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to hold all player data during game
public class PlayerData : MonoBehaviour
{

    public bool dead;
    public int score;
    public int numOfCoins;
    private Vector3 lastGroundPos;
    private bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        score = 0;
        numOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if (onGround)
            lastGroundPos = transform.position;

        if (transform.position.y < lastGroundPos.y - 20f)
            dead = true;

        if (dead)
            ; //todo: change to die screen
        else if (transform.position.x > lastGroundPos.x)
            score += 10;
    }

    void OnCollisionEnter2D(Collision2D obj)
    { 
        if (obj.gameObject.tag == "ground")
        {
            onGround = true;
        } else if (obj.gameObject.tag == "enemy")
		{
            dead = true;
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
