using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //players movement

    public float moveSpeed, jumpHeight;
    public bool onGround = false;
    public Joystick joystick; //dev control (wont be in final release)
    public float horizontalMove;
    public float jump = 0;

    // Update is called once per frame
    void Update(){

        //horizontalMove = joystick.Horizontal; //if (horizontalMove > 0)

        //todo: remove joystick and manual x-axis movement (limit to jumping)
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);

       /* if (horizontalMove > 0)
        {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
        else if (horizontalMove < 0)
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }*/

        //td: change jump to be a tap on the right side of the screen
        //td: attack is a double tap on right screen (or implement two buttons one for jump one for attack 

        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
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
