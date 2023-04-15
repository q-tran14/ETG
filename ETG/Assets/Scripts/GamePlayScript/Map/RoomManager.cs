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
    public bool isClear = false;
    public int spawnRoundMax = 2,spawnRoundMin = 1;
    
    // A number of enemies spawn each time
    private int numEnemyPerTimeSpawnMin;
    public int numEnemyPerTimeSpawnMax = 8; 

    [Serializable]
    public struct ranPosD
    {
        public int round;
        public List<Vector3Int> ranPosL;
        public ranPosD(int i, List<Vector3Int> l)
        {
            this.round = i;
            this.ranPosL = l;
        }
    }

    public List<ranPosD> ranPosDs;
    // ChamberManager to get chamber enemy list
    public GameObject[] doors;
    public GameObject[] enemies;

    // Room Area
    public List<Vector3Int> trackedCells;


    // Start is called before the first frame update
    void Start()
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
        StartCoroutine(SpawnPosition());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPosition() // Initialization number spawn round for each room, number enemy for each spawn round, spawn position for enemies when enter the chamber
    {
        yield return new WaitForSeconds(1f);
        if (trackedCells.Count > 0)
        {
            int spawnRound = Random.Range(spawnRoundMin, spawnRoundMax+1);
            for (int j = 1; j <= spawnRound; j++)
            {
                int numEnemyPerTimeSpawn = Random.Range(numEnemyPerTimeSpawnMin, numEnemyPerTimeSpawnMax); //A Number of enemies spawn in each round
                List<Vector3Int> ranPosL = new List<Vector3Int>();
                for (int i = 0; i < numEnemyPerTimeSpawn; i++)
                {
                    int ran;
                    Vector3Int ranPos;
                    ran = Random.Range(0, trackedCells.Count - 1);
                    ranPos = trackedCells.ToArray()[ran];
                    ranPosL.Add(ranPos);
                }
                ranPosD n = new ranPosD(j, ranPosL);
                ranPosDs.Add(n);
            }
        }
    }
}
