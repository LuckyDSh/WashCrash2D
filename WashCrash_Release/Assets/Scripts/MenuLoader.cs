using UnityEngine;

public class MenuLoader : MonoBehaviour
{

    public string musicToPlay;
    public static bool isMusicPlaying = true;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.instance;
        isMusicPlaying = true;
        PlayMusic(musicToPlay);
    }

    public void PlayMusic(string musicToPlay)
    {
        audioManager.Play(musicToPlay);
    }

    public void StopMusic(string musicToStop)
    {
        audioManager.Stop(musicToStop);
    }

}
