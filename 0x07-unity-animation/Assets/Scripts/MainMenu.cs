using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// method for selecting levels
    /// </summary>
    /// <param name="level"></param>
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene("Level0" + level);
    }
    public void Options()
    {
        PlayerPrefs.SetString("previousScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}