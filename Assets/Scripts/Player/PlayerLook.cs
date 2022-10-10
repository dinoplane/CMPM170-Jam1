using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public Vector2 mouseInput;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    private GameObject joint;

    public void OnLook(InputAction.CallbackContext context){
        switch (context.phase){
            case InputActionPhase.Started:
                mouseInput = context.ReadValue<Vector2>();
                break;
            case InputActionPhase.Performed:

                break;
            case InputActionPhase.Canceled:
                mouseInput = Vector2.zero;
                break;
        }
    }
     
    public void ProcessLook(){
        xRotation -= (mouseInput.y * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        //apply to camera
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //joint.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // rotate player
        transform.Rotate(Vector3.up * (mouseInput.x * Time.deltaTime) * xSensitivity);
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        joint = GameObject.Find("Joint");
    }

    // Update is called once per frame
    void Update()
    {
        ProcessLook();
    }
}
