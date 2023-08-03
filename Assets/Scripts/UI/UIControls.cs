using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControls : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void NextTarget()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Brawl()
    {
        SceneManager.LoadScene(2);
    }

    public void MissionBig()
    {
        SceneManager.LoadScene(3);
    }

    public void GoMenu()
    {

        SceneManager.LoadScene(0);
    }

    public void ToggleOptions()
    {

    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
