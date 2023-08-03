using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenu;

    private void Start()
    {
        PauseMenu.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            {
                if (GameIsPaused)
                {
                    resume();
                }
                else
                {
                    PauseGame();
                }
            }
        }

    }

    void resume()
    {
        PauseMenu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    void PauseGame()
    {
        PauseMenu.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
        GameIsPaused = true;
    }
}
