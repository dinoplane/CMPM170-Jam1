using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 playerVelocity;
    private float playerSpeed = 5.0f;
    private CharacterController controller;

    private float modifier = 1.0f;

    // Start is called before the first frame update
    void Awake()
    {   
        controller = GetComponent<CharacterController>();
    }

    public void OnMovement(InputAction.CallbackContext context){

        //Debug.Log($"Movement {context.phase} {context.ReadValue<Vector2>()}");
        Vector2 curr_val = context.ReadValue<Vector2>();
        switch (context.phase){
            case InputActionPhase.Started:
                playerVelocity.x = curr_val.x;
                playerVelocity.z = curr_val.y;
                break;
            
            case InputActionPhase.Performed:
                playerVelocity.x = curr_val.x;
                playerVelocity.z = curr_val.y;
                break;
            
            case InputActionPhase.Canceled:
                playerVelocity = Vector3.zero;
                break;
        }
    }


    public void ProcessMove(){
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = playerVelocity.x;
        moveDirection.z = playerVelocity.z; 
        controller.Move(transform.TransformDirection(moveDirection) * playerSpeed * Time.deltaTime * modifier);
    }

    // Update is called once per frame
    void Update()
    {
            ProcessMove();
    }
}
