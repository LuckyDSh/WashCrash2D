﻿/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoad : MonoBehaviour
{
    public GameObject pressAgain;
    private bool escape = false;
    private bool pressedTwice = false;
    [SerializeField] private GameObject[] transitionEffects;

    private void Update()
    {
        Cursor.visible = true;

        if (Input.GetKeyDown(KeyCode.Escape) && !pressedTwice)
        {
            Debug.Log("Escape ... ");

            if (!pressAgain.activeSelf)
            {
                pressAgain.SetActive(true);
                Debug.Log("Reactivation");
            }
            pressedTwice = true;
            return;

        }
        if (Input.GetKeyDown(KeyCode.Escape) && pressedTwice)
        {
            pressAgain.SetActive(false);
            pressedTwice = false;
            escape = true;
        }

        Escape();
    }

    public void Escape()
    {
        if (escape)
        {
            Application.Quit();
        }
    }

    public void LoadNextLevel_Launcher()
    {
        StartCoroutine(LoadNextLevel());
    }

    public IEnumerator LoadNextLevel()
    {
        foreach(var effect in transitionEffects)
        {
            effect.SetActive(true);
        }

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadPreviousLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadThisLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}