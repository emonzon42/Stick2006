using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 30.0f;

    private void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            transform.position = new Vector3(player.position.x, player.position.y+4, transform.position.z);
  
    }
}
