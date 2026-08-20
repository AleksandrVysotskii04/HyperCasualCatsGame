using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float distance;
    public float height;
    public float smoothness;
    public Transform target;
    Vector3 velocity;

    void LateUpdate()
    {
        Vector3 pos = Vector3.zero;
        pos.x = target.position.x;
        pos.y = target.position.y + height;
        pos.z = target.position.z - distance;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothness);

    }


}
