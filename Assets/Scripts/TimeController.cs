using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeController : MonoBehaviour {

    public static TimeController instance;

    public Text timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elaspedTime;


    private void Awake() {
        if(instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        
    }

    // Start is called before the first frame update
    private void Start() {
        timeCounter.text = "00:00:00";
        timerGoing = false;
        this.BeginTimer();
    }

    public void BeginTimer() {
        timerGoing = true;
        elaspedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer() {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer() {
        while (timerGoing) {
            elaspedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elaspedTime);
            string timePlayingStr = timePlaying.ToString("hh':'mm':'ss");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
}
