using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Hobgoblin; //Gremlin Manager
    //public ArrayList Spawnpoints;
    public int mySpawnNum;
    void Start()
    {
        // Hobgoblin manages the gremlins
        Hobgoblin = GameObject.Find("GremlinManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Collision Detection
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Swatter")
        {
            // If swatter hits Gremlin, remove/destroy that gremlin
            Hobgoblin.GetComponent<GremlinManagerScript>().RemoveGobby(mySpawnNum);
            Destroy(this.gameObject);
        }
    }
    public void setSpawnNum(int x)
    {
        mySpawnNum = x;
    }
}
