/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;

public class ClickSoundHandler : MonoBehaviour
{
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>();
        audioManager.Play("MenuTheme");
    }

    public void PlaySound(string name)
    {
        audioManager.Play(name);
    }
}
