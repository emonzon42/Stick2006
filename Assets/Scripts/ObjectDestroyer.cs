using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    //destroys gameobjects that are far from the player

    private const float DESPAWN_DISTANCE = 400f; //the distance between player and next object despawn
    private GameObject player;
    
    //  Used for initialization
    void Awake()
	{
        player = GameObject.Find("Player");
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < player.transform.position.x - DESPAWN_DISTANCE) //if object is further than set spawn distance from player (should be behind player)
            Destroy(this.gameObject);
    }

    // Sent when another object enters a trigger collider attached to this object
    void OnTriggerEnter2D(Collider2D col)
    {
        if (gameObject.tag == "coin") //if coin is collected by player destroy it
        {
            if (col.gameObject.tag == "Player")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
