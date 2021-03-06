﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public const int MAX = 100000;
    public const int SPAWNCHANCE = 3;

    [SerializeField] public GameObject enemy;
    [SerializeField] private List<Transform> spawnPositions;

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < spawnPositions.Count; i++)
            if (Random.Range(0, MAX) % SPAWNCHANCE == 0) //if random number is a scalar multiple of SPAWNCHANCE then enemy will spawn
                SpawnEnemy();
    }

    // Spawns enemies at one of the spawn positions
	private void SpawnEnemy()
	{
        Transform spawnPos = spawnPositions[Random.Range(0, spawnPositions.Count)];
        spawnPositions.Remove(spawnPos); //removes to avoid multiple enemys spawning on same spot

        Instantiate(enemy, spawnPos.position, Quaternion.identity);
    }

}
