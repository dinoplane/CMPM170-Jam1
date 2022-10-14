using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.InputSystem;

public class PlayerHit : MonoBehaviour
{
    private GameObject joint;
    private GameObject swatter;
    private FinaleManagerScript fn;

    private bool isSwinging = false;

    // Start is called before the first frame update
    void Start()
    {
        joint = GameObject.Find("Joint");
        swatter = GameObject.Find("Swatter");
        fn = GameObject.Find("FinaleManager").GetComponent<FinaleManagerScript>();
    }

    public void OnSwing(InputAction.CallbackContext context){

        switch (context.phase){
            case InputActionPhase.Started:
                if (!isSwinging){
                    StartCoroutine(Swing());
                }
                if (UnityEngine.Cursor.visible && !fn.trigger){
                    UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                    UnityEngine.Cursor.visible = false;
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
        for (int i = 0; i < 20; i++){
            joint.transform.Rotate(new Vector3(5, 0, 0));
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < 20; i++){
            joint.transform.Rotate(new Vector3(-5, 0, 0));
            yield return null;
        }   
        isSwinging = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
