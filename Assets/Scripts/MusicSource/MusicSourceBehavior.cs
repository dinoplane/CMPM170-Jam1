using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSourceBehavior : MonoBehaviour
{
    private GameObject currGremlin;
    private bool isSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {   
        Debug.Log("Beep");
        if (collision.gameObject.tag == "Gremlin")
        {   
            currGremlin = collision.gameObject;
            isSpawned = true;
            gameObject.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("IsGremlinAlive", 1);
        }
    }

    // void OnTriggerExit(Collider collision)
    // {   
    //     Debug.Log("Bop");
    //     if (collision.gameObject.tag == "Gremlin")
    //     {
    //         Debug.Log("I'm a shot");
    //     }
    // }
    

    // Update is called once per frame
    void Update()
    {   
        // Check if gremlin is destroyed
        if (isSpawned && currGremlin == null)   {
           gameObject.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("IsGremlinAlive", 0);
            isSpawned = false;
        }
     
    }
}
