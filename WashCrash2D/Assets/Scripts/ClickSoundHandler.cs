using UnityEngine;

public class ClickSoundHandler : MonoBehaviour
{
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>(); 
    }

    public void PlaySound(string name)
    {
        audioManager.Play(name);
    }
}
