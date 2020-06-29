using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGeneration : MonoBehaviour
{
    //how the platforms generate

    private const float SPAWN_DISTANCE = 200f;

    [SerializeField] private List<Transform> levelParts; //all level parts that can be spawned
    [SerializeField] private Transform levelStart;
    [SerializeField] public GameObject player;

    private Vector3 lastEndPos;

    private void Awake()
    {
        lastEndPos = levelStart.Find("EndPos").position;
        
        int startingSpawns = 5;
        for(int i = 0; i < startingSpawns; i++){
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPos) < SPAWN_DISTANCE)
            SpawnLevelPart();
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelParts[Random.Range(0, levelParts.Count)];

        Transform lastLevelPart = SpawnLevelPart(chosenLevelPart, lastEndPos /*+ new Vector3(2,0)*/);

        lastEndPos = lastLevelPart.Find("EndPos").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPos)
    {
        Transform lastLevelPart = Instantiate(levelPart, spawnPos, Quaternion.identity);
        return lastLevelPart;
    }

}
