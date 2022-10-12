using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaleManagerScript : MonoBehaviour
{
    private bool trigger = false;
    public short musicCount = 0;

    //public GameObject musicSource;
    //public MusicSourceBehavior musicSourceScript;
    public GameObject musicBox = null;

    

    // Start is called before the first frame update
    void Start()
    {
        //musicSourceScript = musicSource.GetComponent<MusicSourceBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        //musicCount = musicSourceScript.musicCount;
        if (trigger == false && musicCount == 5)
        {
            Instantiate(musicBox, transform.position, Quaternion.identity);
            trigger = true;
        }
    }
}
