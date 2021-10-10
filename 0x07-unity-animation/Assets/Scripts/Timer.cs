using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Timer : MonoBehaviour
{
    public Text TimerText;
    public float millisec, sec, min, iTimer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        iTimer += Time.deltaTime;
        millisec = (int)(iTimer * 100) % 100;
        sec = (int)(iTimer % 60f);
        min = (int)(iTimer / 60f);
        TimerText.text = String.Format("{0:0}:{1:00}:{2:00}",min,sec,millisec);

    }
}
