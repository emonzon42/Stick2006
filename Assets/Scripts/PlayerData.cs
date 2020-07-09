using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to hold all player data during game (Movement/Score/Life)
public class PlayerData : MonoBehaviour
{
    public float moveSpeed, jumpHeight; //movement
    public bool onGround, firstLaunch; // ..
    private Vector3 startPos;

    public bool dead; //Life

    public int score, numOfCoins; //Score

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        score = 0;
        numOfCoins = 0;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		if (dead)
            gameObject.SetActive(false); 
		else
		{
            Vector3 currentPos = Movement();

            float distRan = currentPos.x - startPos.x;

            if (distRan > score)
                score++;
        }
    }

    //players movement data
    Vector3 Movement()
	{
        if (Time.fixedTime % 10 == 0) //every 10 seconds
            moveSpeed++;


        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed); //player auto run
            

        //todo: touch control not working as expected (doesn't read 
        bool jumped = (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0); //space button for testing only

        if (jumped && (onGround || firstLaunch)) //player can only double jump before hitting ground
        {
            if (firstLaunch)
                firstLaunch = false; //prevent triple/etc jumping

            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse); //player jump
        }

        return transform.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "deathblock")
            dead = true;
    }

    void OnCollisionEnter2D(Collision2D obj)
    {

        if (obj.gameObject.tag == "ground")
        {
            onGround = true;
            firstLaunch = false;
        }
        else if (obj.gameObject.tag == "enemy")
            dead = true;
        else if (obj.gameObject.tag == "coin")
            numOfCoins++;
    }


    void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "ground")
        {
            onGround = false;
            firstLaunch = true;
        }
    }
}
