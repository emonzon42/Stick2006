using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    //how the platforms generate

    private const float SPAWN_DISTANCE = 200f; //the furthest distance between player and next platform spawn

    [SerializeField] public GameObject player;
    [SerializeField] private Transform levelStart; //start of level
    [SerializeField] private List<GameObject> platformParts; //all platform parts that can be spawned

    private Vector3 lastEndPos; //last end position of platform

    // Used for initialization
    private void Awake()
    {
        platformParts = new List<GameObject>();

        Object[] loadedObjs = Resources.LoadAll("WorldPieces", typeof(GameObject)); //loads all platforms from resources

        foreach (GameObject loadedObj in loadedObjs)
        {
            platformParts.Add(loadedObj);
        }

        lastEndPos = levelStart.Find("EndPos").position;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        int startingSpawns = 5;
        for(int i = 0; i < startingSpawns; i++){
            SpawnPlatform();
        }
    }    
    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPos) < SPAWN_DISTANCE)
            SpawnPlatform();
    }

    //randomly chooses a platform part and calls sister function to spawn it
    private void SpawnPlatform()
    {
        GameObject chosenPart = platformParts[UnityEngine.Random.Range(0, platformParts.Count)];

        GameObject lastPlatform = SpawnPlatform(chosenPart, lastEndPos);

        lastEndPos = lastPlatform.transform.Find("EndPos").position;

    }

    //spawns platforms at spawnPos
    private GameObject SpawnPlatform(GameObject platform, Vector3 spawnPos)
    {
        GameObject lastPlatform = Instantiate(platform, spawnPos, Quaternion.identity);
        
        return lastPlatform;
    }

}
