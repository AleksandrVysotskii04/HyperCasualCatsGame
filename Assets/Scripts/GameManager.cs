using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int level = 0;
    public GameObject[] rooms;
    private void Awake()
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            if (i <= level)
            {
                rooms[i].SetActive(true);
            }
        }
    }
}
