using UnityEngine;
using UnityEngine.UI;

public class SoundButtonController : MonoBehaviour
{
    public Button thisButton;
    public bool isOn = true;
    public Sprite onImage;
    public Sprite offImage;

    public AudioListener audioListener;

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
        thisButton.image.sprite = onImage;
        AudioListener.pause = true;
    }

    public void SetOff()
    {
        isOn = false;
        thisButton.image.sprite = offImage;
        AudioListener.pause = false;
    }
    
}
