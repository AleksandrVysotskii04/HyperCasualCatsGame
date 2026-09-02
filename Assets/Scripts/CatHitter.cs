using UnityEngine;

public class CatHitter : MonoBehaviour
{
    public GameObject[] hitParticles;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Hittable")
        {
            print("Object touched " + hit.gameObject.name);
            hit.gameObject.tag = "Hit";
            Rigidbody obj_rb = hit.gameObject.GetComponent<Rigidbody>();
            obj_rb.isKinematic = false;
            obj_rb.AddExplosionForce(75, transform.position + Vector3.down, 15);
            Instantiate(hitParticles[Random.Range(0, hitParticles.Length)], hit.gameObject.transform.position, Quaternion.identity);
        }
    }
}
