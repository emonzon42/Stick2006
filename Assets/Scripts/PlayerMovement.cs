using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{

    public enum type {platformer, topDown }

    public float moveSpeed, jumpHeight;
    public bool onGround = false;
    public Joystick joystick;
    public float horizontalMove;
    public float jump;

    // Update is called once per frame
    void Update(){

        horizontalMove = transform.position.x; //joystick.Horizonntal
        if (horizontalMove > 0)
        {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
        else if (horizontalMove < 0)
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
        jump = transform.position.y;//joystick.Vertical;
        //td: change jump to be a tap on the right side of the screen
        //td: attack is a double tap on right screen (or implement two buttons one for jump one for attack 

        

        if(jump > 0 && onGround)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
       if (obj.gameObject.tag == "ground" && jump == 0)
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
