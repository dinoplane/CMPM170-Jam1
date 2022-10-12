using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaleManagerScript : MonoBehaviour
{
    private bool trigger = false;
    public short musicCount = 0;

    //public GameObject musicSource;
    //public MusicSourceBehavior musicSourceScript;
    public GameObject flySwatter = null;
    public GameObject musicBox = null;
    public GameOverScript GameOver;
    public GameObject conductor;
    
    IEnumerator GameOverSequence()
    {
        Instantiate(musicBox, transform.position, Quaternion.identity);
        trigger = true;
        flySwatter.GetComponent<BoxCollider>().enabled = false;
        conductor.SetActive(true);
        conductor.transform.position = new Vector3(-0.37f, 1.4f, -7.66f);
        yield return StartCoroutine(GameOverCoroutine());
        GameOver.Setup();
    }

    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(8.5f);
    }

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
            trigger = true;
            StartCoroutine(GameOverSequence());
        }
    }
}
