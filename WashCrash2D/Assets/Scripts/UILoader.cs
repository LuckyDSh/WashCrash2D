using UnityEngine;

public class UILoader : MonoBehaviour
{
    public GameObject uiToLoad;
    public bool isActive = false;

    public void Loading()
    {
        if (isActive)
        {
            DeActivateUI();
        }
        else
        {
            ActivateUI();
        }
    }

    public void ActivateUI()
    {
        isActive = true;
        uiToLoad.SetActive(true);
    }

    public void DeActivateUI()
    {
        isActive = false;
        uiToLoad.SetActive(false);
    }
}
