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
            audio.SoundOn();
    }

    public void SetOff()
    {
        isOn = false;
        thisButton.image.sprite = offImage;
        if (audio != null)
            audio.Silence();
    }

}
