using Enemy;
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
    public List<GameObject> enemyInRoom;
    public bool isClear = false;
    public int spawnRoundMax = 2,spawnRoundMin = 1, spawnRound;
    
    // A number of enemies spawn each time
    private int numEnemyPerTimeSpawnMin;
    public int numEnemyPerTimeSpawnMax;

    // Neighborhood room
    public GameObject[] doors;
    // ChamberManager to get chamber enemy list
    public GameObject[] enemies;

    // Room Area
    public List<Vector3Int> trackedCells;


    // Start is called before the first frame update
    void Awake()
    {
        if (trackedCells.Count <= 1000) 
        { 
            numEnemyPerTimeSpawnMin = 1; //3
        }
        if (trackedCells.Count > 1000 && trackedCells.Count <= 1600)
        {
            numEnemyPerTimeSpawnMin = 1; //4
        }
        if (trackedCells.Count > 1600)
        {
            numEnemyPerTimeSpawnMin = 1; //5
        }
        spawnRound = 1;//Random.Range(spawnRoundMin, spawnRoundMax + 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for(int i = 0; i < enemyInRoom.Count; i++)
        {
            if (enemyInRoom[i] == null) enemyInRoom.RemoveAt(i);
        }
        if(player != null) RoomCleared();
        if (isClear == true) gameObject.GetComponent<RoomManager>().enabled = false;
    }

    void Spawn() // Initialization number spawn round for each room, number enemy for each spawn round, spawn position for enemies when enter the chamber
    {
        if (trackedCells.Count > 0)
        {
            int numEnemyPerTimeSpawn = 1;
            if (numEnemyPerTimeSpawnMax != 1) numEnemyPerTimeSpawn = Random.Range(numEnemyPerTimeSpawnMin, numEnemyPerTimeSpawnMax); //A Number of enemies spawn in each round
            for (int i = 0; i < numEnemyPerTimeSpawn; i++)
            {
                // Random spawn position and enemy
                int ran = Random.Range(0, trackedCells.Count - 1);
                int e = Random.Range(0, enemies.Length - 1);
                Vector3Int ranPos = trackedCells.ToArray()[ran];

                // Instantiate enemy at random position and set target = player
                GameObject enemy = enemies[e];
                if(enemy.GetComponent<Enemy.Enemy>() != null) enemy.GetComponent<Enemy.Enemy>().target = player;
                if (enemy.GetComponent<Enemy.Boss>() != null) enemy.GetComponent<Enemy.Boss>().target = player;
                GameObject tmp = Instantiate(enemy, new Vector3(ranPos.x, ranPos.y, ranPos.z), Quaternion.identity);
                enemyInRoom.Add(tmp);
            }
            spawnRound -= 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(collision.name == "Hunter")
            {
                foreach (GameObject d in doors)
                {
                    d.GetComponent<Door>().roomClear = false;
                    d.GetComponent<Door>().Close();
                }
                player = collision.gameObject;
                Spawn();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
    void RoomCleared()
    {
        if (enemyInRoom.Count == 0 && spawnRound == 0)
        {
            foreach (GameObject d in doors)
            {
                d.GetComponent<Door>().roomClear = true;
                d.GetComponent<Door>().Open();
            }
            isClear = true;
        }
        else if (enemyInRoom.Count == 0 && spawnRound != 0)
        {
            Spawn();
        }
    }
}
