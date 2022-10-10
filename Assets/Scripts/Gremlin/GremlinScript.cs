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
        Hobgoblin = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Swatter")
        {
            //GremlinManagerScript set its Spawnpoint[mySpawnNum]=false
            //GremlinManagerScript adjust RER
            //Maybe do puff of smoke
            //destroy this obj
        }
    }

    void setSpawnNum(int x)
    {
        mySpawnNum = x;
    }
}
