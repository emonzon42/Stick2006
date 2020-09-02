using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Player player;
    public float cameraDistance = 30.0f;
    private float timeAtEdge; //fixed time when player is first detected near edge
    private bool moveBack;

    //  Used for initialization
    private void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 4, transform.position.z); //camera starts with player in middle of view
    }

    // FixedUpdate is called every fixed frame-rate frame
    void FixedUpdate()
    {
        if(!player.dead && !moveBack)
            transform.Translate(Vector2.right * Time.deltaTime * player.moveSpeed); //camera moves at same pace as player
        else if (moveBack)
            transform.Translate(Vector2.left * Time.deltaTime * (player.moveSpeed+5)); //camera backtracks to allow player to catch up

        transform.position = new Vector3(transform.position.x, player.transform.position.y + 4, transform.position.z); //keeps it at same height as player

        if (PlayerIsNearEdge())
        {
            if (timeAtEdge == 0)
                timeAtEdge = Time.fixedTime;
            else if (Time.fixedTime - timeAtEdge > 7) //player has been close to edge for 7+ seconds
                moveBack = true;
        }
        else
        {
            moveBack = false;
            timeAtEdge = 0;
        }
    }
    // Checks if player is player is near edge of screen
    bool PlayerIsNearEdge()
    {
        if (player.transform.position.x < transform.position.x - 25)
            return true;
        else
            return false;
    }
}
