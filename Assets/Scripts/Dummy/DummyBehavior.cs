using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
