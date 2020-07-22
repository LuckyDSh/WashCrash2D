/*
* TickLuck Team
* All rights reserved
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    public GameObject pressAgain;
    private bool escape = false;
    private bool pressedTwice = false;

    private void Update()
    {
        Cursor.visible = false;

        if (Input.GetKeyDown(KeyCode.Escape) && !pressedTwice)
        {

            pressAgain.SetActive(true);
            pressedTwice = true;
            return;

        }
        if(Input.GetKeyDown(KeyCode.Escape) && pressedTwice)
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

    public void LoadNextLevel()
    {
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
