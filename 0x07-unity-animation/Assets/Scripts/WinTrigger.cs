using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text time;
    public GameObject winCanvas;
    public GameObject timerCanvas;
    public Text finalTime;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Timer>().enabled = false;
            time.fontSize = 150;
            time.color = Color.green;
            Win();

        }
    }
    public void Win()
    {

        winCanvas.SetActive(true);
        timerCanvas.SetActive(false);
        finalTime.text = time.text;
    }
}
