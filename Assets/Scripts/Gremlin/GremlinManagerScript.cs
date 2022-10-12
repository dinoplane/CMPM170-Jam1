using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinManagerScript : MonoBehaviour
{
    
    public float RER = 3.0f; //Random Encounter Rate
    public float elapsedTime;
    public float totalTime;
    //RER varies based on number of gremlins spawned
    //every time we add a gremlin, check if we have reached max, if so start climax
    public GameObject GremlinPrefab;
    public GameObject[] Spawnpoints;
    public ScoreManager scoremng;
    public List<int> freeSpawns = new List<int>();

    void Start()
    {
        // get number of spawnpoints
        for(int x = 0; x<Spawnpoints.Length; x++)
        {
            freeSpawns.Add(x);
        }
        elapsedTime = 0;
        totalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //increment timer, if timer==RER
        elapsedTime += Time.deltaTime;
        totalTime += Time.deltaTime;
        if (elapsedTime >= RER)
        {
            // Spawn Gremlin
            Spawn();
            // reset timer
            elapsedTime = 0;
        }
        

    }

    void IncrementRER()
    {
        if (freeSpawns.Count == Spawnpoints.Length-1)
        {
            RER += 2;
        }
        RER += 1;
        elapsedTime = 0;
    }

    void DecrementRER()
    {
        if (freeSpawns.Count == Spawnpoints.Length)
        {
            RER = 2;
        }
        RER -= 1;
        elapsedTime = 0;
    }

    void Spawn()
    {
        // If no spawns left, no more spawn
        if (freeSpawns.Count == 0)
        {
            return;
        }

        // Get random location of spawnpoint to place gremlin
        int loc = Random.Range(1, freeSpawns.Count)-1;
        //int loc2 = Random.Range(1, Spawnpoints[loc].Length) - 1;
        Vector3 spawnPos= Spawnpoints[freeSpawns[loc]]/*[loc2]*/.transform.position; // get position in 3D coordinates of spawnpoint object
        
        GameObject babyGremlin = Instantiate(GremlinPrefab, spawnPos, Quaternion.identity); // Create gremlin instance and place it
        babyGremlin.GetComponent<GremlinScript>().setSpawnNum(freeSpawns[loc]);
        babyGremlin.transform.Rotate(-90, 0, 0); // rotate gremlin so it is standing
        freeSpawns.RemoveAt(loc);
        IncrementRER(); // update encoutner rate of gremlin
    }
        

    // Remove gremlin once git with the swatter
    public void RemoveGobby(int num)
    {
        freeSpawns.Add(num);
        DecrementRER();
        scoremng.IncrementScore();
    }
}
