using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{

    public GameObject uiToActivate;
    public Slider slider;

    private Enemy[] enemies;

    // Update is called once per frame
    void Update()
    {
        enemies = FindObjectsOfType<Enemy>();

        if (slider.value == slider.maxValue)
        {
            uiToActivate.SetActive(true);
            foreach (var enemy in enemies)
            {
                if (enemy == null)
                    return;

                enemy.Die();
            }
           StartCoroutine(LoadNewScene(5));
        }
    }

    public static IEnumerator LoadNewScene(int time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(0);
        yield return null;
    }

}
