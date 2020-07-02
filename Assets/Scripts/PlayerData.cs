using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to hold all player data during game (Movement/Score/Life)
public class PlayerData : MonoBehaviour
{
    public float moveSpeed, jumpHeight; //movement
    public bool onGround, firstLaunch; // ..

    public bool dead; //Life

    public int score, numOfCoins; //Score

    private Vector3 lastGroundPos; //last held position on ground block

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
		if (Alive() )
		{
            Movement();
		}
		else
		{
            ;//todo: change to die screen
        }
    }

    //checks every frame update if player is alive and whether to continue giving points points
    bool Alive()
	{
        if (onGround)
            lastGroundPos = transform.position;

        if (transform.position.y < lastGroundPos.y - 20f) //if player drops 
            dead = true;

        if (dead)
            return false; 
        else if (transform.position.x > lastGroundPos.x)
            score += 10;
        return true;
    }

    void Movement()
	{
        if (Time.fixedTime % 10 == 0) //every 10 seconds
            moveSpeed++;

        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed); //player auto run

        if (Input.GetKeyDown(KeyCode.Space) && (onGround || firstLaunch)) //player can only double jump before hitting ground
        {
            if (firstLaunch)
                firstLaunch = false; //prevent triple/etc jumping

            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse); //player jump
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    { 
        if (obj.gameObject.tag == "ground")
        {
            onGround = true;
            firstLaunch = false;
        }
        else if (obj.gameObject.tag == "enemy")
		{
            dead = true;
		}
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
