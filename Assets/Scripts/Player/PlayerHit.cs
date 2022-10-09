using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.InputSystem;

public class PlayerHit : MonoBehaviour
{
    private GameObject joint;
    private GameObject swatter;

    private bool isSwinging = false;

    // Start is called before the first frame update
    void Start()
    {
        joint = GameObject.Find("Joint");
        swatter = GameObject.Find("Swatter");
        
    }

    public void OnSwing(InputAction.CallbackContext context){

        switch (context.phase){
            case InputActionPhase.Started:
                Debug.Log("Rotateo");
                if (!isSwinging){
                    StartCoroutine(Swing());
                }
                    
                break;
            
            case InputActionPhase.Performed:

                break;
            
            case InputActionPhase.Canceled:

                break;
        }
    }

    IEnumerator Swing(){
        isSwinging = true;
        for (int i = 0; i < 100; i++){
            joint.transform.Rotate(new Vector3(1, 0, 0));
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < 100; i++){
            joint.transform.Rotate(new Vector3(-1, 0, 0));
            yield return null;
        }   
        isSwinging = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
