using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    Text text;
    float currentTime;
    bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {   
            currentTime += Time.deltaTime;
            string hours = PlayerPrefs.GetInt("hours").ToString("00");
            string minutes = PlayerPrefs.GetInt("minutes").ToString("00");
            string seconds = PlayerPrefs.GetInt("seconds").ToString("00");
            int hoursInt = (int)(Mathf.Floor((currentTime % 216000) / 3600));
            hours = Mathf.Floor((currentTime % 216000) / 3600).ToString("00");
            int minutesInt = (int)(Mathf.Floor((currentTime % 3600) / 60));
            minutes = Mathf.Floor((currentTime % 3600) / 60).ToString("00");
            int secondsInt = (int)(Mathf.Floor(currentTime % 60));
            seconds = Mathf.Floor(currentTime % 60).ToString("00");

            PlayerPrefs.SetInt("hours", hoursInt);
            PlayerPrefs.SetInt("minutes", minutesInt);
            PlayerPrefs.SetInt("seconds", secondsInt);
            
            text.text = hours + ":" + minutes + ":" + seconds;


    }

}
