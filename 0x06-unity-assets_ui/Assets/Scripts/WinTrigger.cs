using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text TimerText;
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Timer>().enabled = false;
            TimerText.fontSize = 60;
            TimerText.color = Color.green;
        }
    }
}
