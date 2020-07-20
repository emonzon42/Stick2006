using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to hold all player data during game (Movement/Score/Life)
public class PlayerData : MonoBehaviour
{
    public float moveSpeed, jumpHeight, footRadius; //Movement
    public LayerMask whatIsGround;
    public Transform feetPos;
    public bool onGround, firstLaunch; 
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

    void FixedUpdate()
    {
        if (!GetComponent<SpriteRenderer>().IsVisibleFrom(Camera.main)) //if player is no longer in view of camera (i.e. player crashed too many times)
            dead = true;
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
            {
                score++;

                if (score % 100 == 0) //every 100 points
                    moveSpeed++;

            }
        }
    } 

    //players movement data
    Vector3 Movement()
	{

        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed); //player auto run           

        bool jumped = ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space)); //player tapped the screen / pressed space button

        onGround = Physics2D.OverlapCircle(feetPos.position, footRadius, whatIsGround);

        if (onGround)
            firstLaunch = false;

        if (jumped && (onGround || firstLaunch)) //player can only double jump before hitting ground
        {
            //prevents triple/etc jumping
            if (firstLaunch)
                firstLaunch = false;
            else
                firstLaunch = true;

            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse); //player jump
            
        }

        return transform.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "deathblock")
            dead = true;
        else if (col.gameObject.tag == "coin")
            numOfCoins++;
    }

    void OnCollisionEnter2D(Collision2D obj)
    {

        if (obj.gameObject.tag == "enemy")
            dead = true;
      
    }  

}
