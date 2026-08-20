using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleTouchToMove : MonoBehaviour
{
    public float Xmin;
    public float Xmax;

    [Header("Input Actions")]
    public InputActionReference pressAction;
    public InputActionReference deltaAction;

    public CharacterController characterController;


    Vector2 initPos;
    Vector2 direction;
    Vector3 moveDirection;
    public float speed = 5.0f;
    bool canMove = false;
    public float gravity = -10.0f;


    void Update()
    {
        if (pressAction != null && pressAction.action.IsPressed())
        {
            canMove = true;
            //Movement calculation


        }
        else
        {
            canMove = false;
            moveDirection = Vector3.zero;
        }
    }
}