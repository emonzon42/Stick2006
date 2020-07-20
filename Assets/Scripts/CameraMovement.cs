using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public PlayerData player;
    public float cameraDistance = 30.0f;

    private void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 4, transform.position.z); //camera starts with player in middle of view
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!player.dead)
            transform.Translate(Vector2.right * Time.deltaTime * player.moveSpeed); //camera moves at same pace as player

        transform.position = new Vector3(transform.position.x, player.transform.position.y + 4, transform.position.z); //keeps it at same height as player
    }
}
