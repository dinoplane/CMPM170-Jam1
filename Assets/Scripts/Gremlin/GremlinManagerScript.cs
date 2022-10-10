using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    //Array or list of Spawnpoints
    //Binary Array noting if a spawnpoint is taken 
    //Timer
    //var RER //Random Encounter Rate
    //RER varies based on number of gremlins spawned
    //every time we add a gremlin, check if we have reached max, if so start climax
    public GameObject GremlinPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //increment timer, if timer==RER
        Spawn();
        //reset timer.

    }

    void Spawn()
    {
        //create new instance of gremlin
        //put a gremlin in a spawnpoint by an instrument w/o gremlins
        //spawn at coordinates of spawnpoint, sending Gremlin it's index in spawnpoint array
        //maybe spawn puff of smoke on spawn point
        //check if RER changes
    }

    void UpdateRER()
    {
        //check how many gremlins exist
        //Set RER accordingly
    }

    void UpdateList()
    {

    }
}
