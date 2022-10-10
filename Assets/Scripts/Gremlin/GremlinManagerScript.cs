using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    //Array or list of Spawnpoints
    //Binary Array noting if a spawnpoint is taken 
    //Timer
    public float RER = 3.0f; //Random Encounter Rate
    public float elapsedTime;
    //RER varies based on number of gremlins spawned
    //every time we add a gremlin, check if we have reached max, if so start climax
    public GameObject GremlinPrefab;
    public GameObject[] Spawnpoints;
    public List<int> freeSpawns = new List<int>();
    //public int  = true;
    //*
    void Start()
    {
        //filledSpawns = new bool[Spawnpoints.Length];
        for(int x = 0; x<Spawnpoints.Length; x++)
        {
            freeSpawns.Add(x);
        }
        elapsedTime = 0;
    }
    //*/

    // Update is called once per frame
    void Update()
    {
        //increment timer, if timer==RER
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= RER)
        {
            Spawn();
            elapsedTime = 0;
        }
        //reset timer.

    }

    void Spawn()
    {
        //create new instance of gremlin
        //put a gremlin in a spawnpoint by an instrument w/o gremlins
        //spawn at coordinates of spawnpoint, sending Gremlin it's index in spawnpoint array
        //maybe spawn puff of smoke on spawn point
        //check if RER changes
        if (freeSpawns.Count == 0)
        {
            return;
        }
        int loc = Random.Range(1, freeSpawns.Count)-1;
        Vector3 spawnPos= Spawnpoints[freeSpawns[loc]].transform.position;
        
        GameObject babyGremlin = Instantiate(GremlinPrefab, spawnPos, Quaternion.identity); //, Quaternion.identity);
        /*if (Input.GetKeyDown(KeyCode.Space)){
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));
            Instantiate(GremlinPrefab, randomSpawnPosition, Quaternion.identity);
        }*/
        babyGremlin.GetComponent<GremlinScript>().setSpawnNum(freeSpawns[loc]);
        babyGremlin.transform.Rotate(-90, 0, 0);
        freeSpawns.RemoveAt(loc);
        RER += 1;
    }

    /*
    void UpdateRER()
    {
        //check how many gremlins exist
        //Set RER accordingly
    }
    */

    
    public void RemoveGobby(int num)
    {
        freeSpawns.Add(num);
        RER -= 1;
    }
}
