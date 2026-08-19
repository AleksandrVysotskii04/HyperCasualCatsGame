using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleTouchToMove : MonoBehaviour
{
    public float speed;
    public float Xmin;
    public float Xmax;

    [Header("Input Actions")]
    // Ссылки на действия, которые мы настроим в редакторе Unity
    public InputActionReference pressAction;
    public InputActionReference deltaAction;

    void Update()
    {
        // Проверяем, выполняется ли действие нажатия (IsPressed)
        if (pressAction != null && pressAction.action.IsPressed())
        {
            // Читаем значение смещения из действия delta
            Vector2 delta = deltaAction.action.ReadValue<Vector2>();

            float newX = transform.position.x + delta.x * speed;
            newX = Mathf.Clamp(newX, Xmin, Xmax);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}