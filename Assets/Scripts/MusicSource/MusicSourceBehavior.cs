using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSourceBehavior : MonoBehaviour
{
    private GameObject currGremlin;
    private bool isSpawned = false;

    // public GameObject musicBox = null;
    // public static short musicCount = 0;
    public FinaleManagerScript finale;

    // Start is called before the first frame update
    void Start()
    {
        // musicBox = GameObject.Find("FinalSong");
    }

    void OnTriggerEnter(Collider collision)
    {   
        //Debug.Log("Beep");
        if (collision.gameObject.tag == "Gremlin")
        {   
            currGremlin = collision.gameObject;
            isSpawned = true;
            gameObject.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("IsGremlinAlive", 1);
            // musicBox = GameObject.Find("FinalSong");
            // musicBox.SetActive(true);
            // Instantiate(musicBox, transform.position, Quaternion.identity);
            finale.musicCount++;
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
        if (isSpawned && currGremlin == null && finale.musicCount < 5)   {
           gameObject.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("IsGremlinAlive", 0);
            isSpawned = false;
            finale.musicCount--;
        }
        else if (finale.musicCount == 5)
        {
            isSpawned = false;
            gameObject.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("IsGremlinAlive", -1);
            // input invincible gremlin logic here;
        }
    }
}
