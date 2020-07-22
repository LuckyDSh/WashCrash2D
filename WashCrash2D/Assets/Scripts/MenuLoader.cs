using UnityEngine;

public class MenuLoader : MonoBehaviour
{

    public string musicToPlay;
    public static bool isMusicPlaying = true;

    private void Start()
    {
        isMusicPlaying = true;
        PlayMusic(musicToPlay);
    }

    public void PlayMusic(string musicToPlay)
    {
        if (musicToPlay == null)
            return;

        FindObjectOfType<AudioManager>().Play(musicToPlay);
        
    }

}
