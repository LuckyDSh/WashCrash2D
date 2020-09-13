/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;
using UnityEngine.UI;

public class SoundButtonController : MonoBehaviour
{
    public Button thisButton;
    public bool isOn = true;
    public Sprite onImage;
    public Sprite offImage;
    private AudioManager audio;

    private void Start()
    {
        isOn = true;
        audio = FindObjectOfType<AudioManager>();
    }

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
        if (audio != null)
        {
            audio.SoundOn();
            audio.Play("MenuTheme");
        }

    }

    public void SetOff()
    {
        isOn = false;
        thisButton.image.sprite = offImage;
        if (audio != null)
            audio.Silence();
    }

}
