using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
public class Obstacle : MonoBehaviour
{
    public float speed = 10.0f;
    public TextMeshProUGUI text;
    public GameObject winParticles;
    public Transform winParticlesPos;
    public GameObject loseParticles;
    void Start()
    {
        try
        {
            winParticlesPos = GameObject.Find("PositionWinParticles").transform;
        }
        catch (Exception e)
        {
            print(e.Message);
        }
        text = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Instantiate(loseParticles, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject, 0.5f);
            Destroy(gameObject.GetComponent("Collider"));
            Destroy(gameObject.GetComponent("MeshRenderer"));
            Invoke("ReloadLevel", 3);

        }
        if (collision.gameObject.name == "Out")
        {
            Instantiate(winParticles, winParticlesPos.position, Quaternion.identity);
            int newScore = int.Parse(text.text) + 1;
            text.text = newScore.ToString();
            Destroy(gameObject);
        }


    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
