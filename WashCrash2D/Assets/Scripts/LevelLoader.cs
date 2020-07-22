using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
   
    private void Start()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        LoadLevel(index + 1);
    }

    public void LoadLevel(int sceneIndex)
    {
        Debug.Log("Loading started ... ");

        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    public IEnumerator LoadAsynchronously(int sceneIndex)
    {
        Debug.Log("Coroutine start ... ");

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        if (loadingScreen != null) 
            loadingScreen.SetActive(true);

        while (!operation.isDone)
        { 
            // making slider go 0-1%
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";
        }

        yield return null;
    }

    public void LoadNextLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
