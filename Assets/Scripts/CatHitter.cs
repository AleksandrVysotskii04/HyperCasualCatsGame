using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatHitter : MonoBehaviour
{
    public GameObject[] hitParticles;
    public GameObject textScore;
    public GameObject textScoreGained;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Hittable")
        {
            print("Object touched " + hit.gameObject.name);
            hit.gameObject.tag = "Hit";
            Rigidbody obj_rb = hit.gameObject.GetComponent<Rigidbody>();
            HittableObject ho = hit.gameObject.GetComponent<HittableObject>();
            obj_rb.isKinematic = false;
            obj_rb.AddExplosionForce(75, transform.position + Vector3.down, 15);
            GameObject spawnedParticle = Instantiate(hitParticles[Random.Range(0, hitParticles.Length)], hit.gameObject.transform.position, Quaternion.identity);
            spawnedParticle.transform.localScale /= 3f;
            iTween.PunchScale(textScore, new Vector3(1.25f, 1.25f, 1.25f), 0.5f);
            int newScore = int.Parse(textScore.GetComponent<TextMeshProUGUI>().text) + ho.points;
            textScore.GetComponent<TextMeshProUGUI>().text = newScore.ToString();
            textScoreGained.GetComponent<TextMeshPro>().text = "+" + ho.points;
            Invoke("ResetTextGained", 0.5f);
        }
    }
    public void ResetTextGained()
    {
        textScoreGained.GetComponent<TextMeshPro>().text = "";
    }
}
