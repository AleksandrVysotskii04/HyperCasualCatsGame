using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;
    void Update()
    {
        transform.LookAt(cam);
    }

}
