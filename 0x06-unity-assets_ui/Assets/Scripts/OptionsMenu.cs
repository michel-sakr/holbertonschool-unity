using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle isInverted;
    void Start()
    {
        if (PlayerPrefs.GetInt("invertedY") == 1)
            isInverted.isOn = true;
        else
            isInverted.isOn = false;
    }
    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("previousScene"));
    }
    public void Apply()
    {
        if (isInverted.isOn == true)
            PlayerPrefs.SetInt("invertedY", 1);
        else
            PlayerPrefs.SetInt("invertedY", 0);
        Back();
    }
}
