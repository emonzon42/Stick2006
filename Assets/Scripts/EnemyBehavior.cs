using static System.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public const float MOVE_SPEED = 2;
    public bool dead;
    public int lastDirection;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        lastDirection = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(dead)
            gameObject.SetActive(false);

        //Enemy makes a move every 1/8th seconds by picking a random num from 0-100
        else if (Time.fixedTime % 0.125 == 0)
		{
            int randnum = Random.Range(-100, 100);
            for (int i = -1; i < Abs(randnum % 10); i++) //moves up to 10 times depending on rand num
            {
                if (randnum > (0 - lastDirection))
                {
                    //transform.Translate(Vector2.right * Time.deltaTime * MOVE_SPEED);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    transform.Translate(Vector2.left * Time.deltaTime * MOVE_SPEED);
                }
                else
                {
                    //transform.Translate(Vector2.left * Time.deltaTime * MOVE_SPEED);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    transform.Translate(Vector2.left * Time.deltaTime * MOVE_SPEED);
                }

            }
            lastDirection = randnum; //tips odds in favor of moving in the same direction as last time
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "attack")
        {
            FindObjectOfType<AudioManager>().Play("enemydeath");
            dead = true;
        }
    }
}
