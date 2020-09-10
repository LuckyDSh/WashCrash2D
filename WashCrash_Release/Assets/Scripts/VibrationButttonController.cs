/*  
*	TickLuck team
*	All rights reserved
*/

using UnityEngine;
using UnityEngine.UI;

public class VibrationButttonController : MonoBehaviour
{
    public Image thisButton;
    public bool isOn = true;
    public Sprite onImage;
    public Sprite offImage;

    public void Switch()
    {
        if (isOn)
        {
            SetOff();
        }
        else
        {
            SetOn();
        }
    }

    public void SetOn()
    {
        isOn = true;
        thisButton.sprite = onImage;
        VibrationController.is_on = true;
    }

    public void SetOff()
    {
        isOn = false;
        thisButton.sprite = offImage;
        VibrationController.is_on = false;

    }
}
