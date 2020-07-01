using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //players movement

    public float moveSpeed, jumpHeight;
    public bool onGround = false;
    public Joystick joystick; //dev control (wont be in final release)
    public float jump = 0;

    // Update is called once per frame
    void Update(){
        if (Time.fixedTime % 10 == 0) //every 10 seconds
            moveSpeed++;

        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);

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
