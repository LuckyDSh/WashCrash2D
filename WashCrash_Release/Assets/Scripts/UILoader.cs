/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;

public class UILoader : MonoBehaviour
{
    public GameObject uiToLoad;
    public GameObject uiToHide;
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
        uiToHide.SetActive(false);
    }

    public void DeActivateUI()
    {
        isActive = false;
        uiToLoad.SetActive(false);
        uiToHide.SetActive(true);
    }
}
