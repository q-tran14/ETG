using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class RoomManager : MonoBehaviour
{
    public GameObject player;
    public bool isClear = false;
    public int spawnRoundMax = 2,spawnRoundMin = 1, spawnRound;
    
    // A number of enemies spawn each time
    private int numEnemyPerTimeSpawnMin;
    public int numEnemyPerTimeSpawnMax = 8;

    // Neighborhood room
    public GameObject[] doors;
    // ChamberManager to get chamber enemy list
    public GameObject[] enemies;
    public int enemiesCurrent;

    // Room Area
    public List<Vector3Int> trackedCells;


    // Start is called before the first frame update
    void Awake()
    {
        if (trackedCells.Count <= 1000) 
        { 
            numEnemyPerTimeSpawnMin = 3;
        }
        if (trackedCells.Count > 1000 && trackedCells.Count <= 1600)
        {
            numEnemyPerTimeSpawnMin = 4;
        }
        if (trackedCells.Count > 1600)
        {
            numEnemyPerTimeSpawnMin = 5;
        }
        spawnRound = Random.Range(spawnRoundMin, spawnRoundMax + 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isClear == true) this.gameObject.SetActive(false);
        //RoomCleared();
    }

    void Spawn() // Initialization number spawn round for each room, number enemy for each spawn round, spawn position for enemies when enter the chamber
    {
        if (trackedCells.Count > 0)
        {
            int numEnemyPerTimeSpawn = Random.Range(numEnemyPerTimeSpawnMin, numEnemyPerTimeSpawnMax); //A Number of enemies spawn in each round
            for (int i = 0; i < numEnemyPerTimeSpawn; i++)
            {
                // Random spawn position and enemy
                int ran = Random.Range(0, trackedCells.Count - 1);
                int e = Random.Range(0, enemies.Length - 1);
                Vector3Int ranPos = trackedCells.ToArray()[ran];

                // Instantiate enemy at random position and set target = player
                GameObject enemy = enemies[e];
                enemy.GetComponent<Enemy>().target = player;
                Instantiate(enemy, new Vector3(ranPos.x, ranPos.y, ranPos.z), Quaternion.identity);

                enemiesCurrent += 1;
            }
            spawnRound -= 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Close door
            player = collision.gameObject;
            Spawn();
        }
    }

    void RoomCleared()
    {
        if (enemiesCurrent == 0 && spawnRound == 0)
        {
            //door open
            isClear = true;
        }
        else if (enemiesCurrent == 0 && spawnRound != 0)
        {
            Spawn();
        }
    }
}
