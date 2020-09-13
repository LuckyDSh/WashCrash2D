/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;

public class StopMusic : MonoBehaviour
{
    private LevelUp level;

    private void OnEnable()
    {
        level = FindObjectOfType<LevelUp>();
    }

    public void Stop_PlayModeTheme()
    {
        foreach (var theme in level.themes_names)
        {
            AudioManager.instance.Stop(theme);
        }
    }

}
