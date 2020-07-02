using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public const float MOVE_SPEED = 20;
    public bool dead;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;

    }

    // Update is called once per frame
    void Update()
    {
       
        //Enemy makes a move every two seconds by picking a random num from 0-100
		if (Time.fixedTime % 2 == 0)
		{
            int randnum = Random.Range(0, 100);
            
            if (randnum < 50)
                transform.Translate(Vector2.right * Time.deltaTime * MOVE_SPEED);
            else
                transform.Translate(Vector2.left * Time.deltaTime * MOVE_SPEED);
        }
        
         
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            ; //PLACEHOLDER
        }
    }

    void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            ;//PLACEHOLDER
        }
    }
}
