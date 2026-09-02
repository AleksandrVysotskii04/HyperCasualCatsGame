using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject shop;
    public void SelectSkin(int skinId)
    {
        print("The player clicked the skin " + skinId);
        //TODO: skin code
        shop.SetActive(false);
    }
}
