using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject shop;
    public CatSkin cs;
    public void SelectSkin(int skinId)
    {
        print("The player clicked the skin " + skinId);
        PlayerPrefs.SetInt("selectedSkin", skinId);
        cs.SetSkin(skinId);
        shop.SetActive(false);
    }
}
