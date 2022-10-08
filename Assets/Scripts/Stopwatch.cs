using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Stopwatch : MonoBehaviour {

    bool stopwatchActive = false;
    float currentTime;
    public int startMinutes;
    public Text currentTimeText;
    // Start is called before the first frame update
    void Start() {
        currentTime = 0;
        StartStopWatch();
    }

    // Update is called once per frame
    void Update() {
        if (stopwatchActive == true) {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }

    public void StartStopWatch() {
        stopwatchActive = true;
    }

    public void StopStopwatch() {
        stopwatchActive = false;
    }
}
