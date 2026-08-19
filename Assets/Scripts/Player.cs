using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;
    public float Xmin;
    public float Xmax;

    void Update()
    {
        if (Pointer.current != null && Pointer.current.press.isPressed)
        {
            Vector2 delta = Pointer.current.delta.ReadValue();
            float newX = transform.position.x + delta.x * speed;
            newX = Mathf.Clamp(newX, Xmin, Xmax);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}