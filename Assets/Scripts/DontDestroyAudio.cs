﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour {
    
    private static DontDestroyAudio instance = null;

    public static DontDestroyAudio Instance {
        get {
            return instance;
        }
    }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // void Awake() {

    //     GameObject[] gameMusic = GameObject.FindGameObjectsWithTag("GameMusic");

    //     if (gameMusic.Length > 1) {
    //         Destroy(this.gameObject);
            
    //     } else {
    //         // instance = this;
    //         DontDestroyOnLoad(this.gameObject);
    //     }
    // }
}
