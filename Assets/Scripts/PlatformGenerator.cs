using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformGenerator : MonoBehaviour
{
    //how the platforms generate

    private const float SPAWN_DISTANCE = 200f; //the furthest distance between player and next platform spawn

    [SerializeField] public GameObject player;
    [SerializeField] private Transform levelStart; //start of level
    [SerializeField] private List<Transform> platformParts; //all platform parts that can be spawned

    private Vector3 lastEndPos; //last end position of platform


    private void Awake()
    {
        lastEndPos = levelStart.Find("EndPos").position;
        
        int startingSpawns = 5;
        for(int i = 0; i < startingSpawns; i++){
            SpawnPlatform();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPos) < SPAWN_DISTANCE)
            SpawnPlatform();
    }

    private void SpawnPlatform()
    {
        Transform chosenPart = platformParts[Random.Range(0, platformParts.Count)];

        Transform lastPlatform = SpawnPlatform(chosenPart, lastEndPos);

        lastEndPos = lastPlatform.Find("EndPos").position;

    }

    private Transform SpawnPlatform(Transform platform, Vector3 spawnPos)
    {
        Transform lastPlatform = Instantiate(platform, spawnPos, Quaternion.identity);
        
        return lastPlatform;
    }

}
