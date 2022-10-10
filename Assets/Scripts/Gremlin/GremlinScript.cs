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
        Hobgoblin = GameObject.Find("GremlinManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        //if (collisionInfo.gameObject.tag == "Swatter")
        //{
            Hobgoblin.GetComponent<GremlinManagerScript>().RemoveGobby(mySpawnNum);
            Destroy(this.gameObject);
            //GremlinManagerScript set its Spawnpoint[mySpawnNum]=false
            //GremlinManagerScript adjust RER
            //Maybe do puff of smoke
            //destroy this obj
        //}
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Swatter")
        {
            Hobgoblin.GetComponent<GremlinManagerScript>().RemoveGobby(mySpawnNum);
            Destroy(this.gameObject);
        }
    }
    public void setSpawnNum(int x)
    {
        mySpawnNum = x;
    }
    /*public void setHobgoblin(GameObject hob)
    {
        Hobgoblin = hob;
    }*/
}
