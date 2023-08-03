using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMan : MonoBehaviour
{
    public GameObject GameOverBad, playerRef, pauseMenu, deathCam, vicCam, REDref, GameOverGood;
    void Start()
    {
        GameOverBad.SetActive(false);
        GameOverGood.SetActive(false);
        deathCam.SetActive(false);
        vicCam.SetActive(false);
    }


    void Update()
    {
        if(playerRef == null)
        {
            GameOverBad.SetActive(true);
            deathCam.SetActive(true);
            pauseMenu.SetActive(false);
            Time.timeScale = 0.6f;
            Cursor.visible = true;
        }

        if(REDref == null)
        {
            GameOverGood.SetActive(true);
            vicCam.SetActive(true);
            pauseMenu.SetActive(false);
            Time.timeScale = 0.6f;
            Cursor.visible = true;
        }


    }
}
