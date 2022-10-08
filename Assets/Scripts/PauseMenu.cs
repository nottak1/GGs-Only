using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    
    public static bool IsPaused = false;

    public static bool inSettings = false;

    public GameObject pauseMenuUI;

    public GameObject settingsMenuUI;

    [SerializeField] Slider volumeSlider;

    void Start() {
        if (!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        } else {
            Load();
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !inSettings) {
            if (IsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && inSettings) {
            LeaveSettings();
        }
    }

    // Resume game
    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        Cursor.visible = false;
        AudioListener.pause = false;
    }

    // Pause game
    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        Cursor.visible = true;
        AudioListener.pause = true;
    }

    // Goes to the settings menu
    public void GoToSettings() {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
        inSettings = true;
    }

    public void LeaveSettings() {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        inSettings = false;
    }

    // Restarts the game to the main menu
    public void RestartGame() {

        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        AudioListener.pause = false;
        TimeController.instance.EndTimer();

        // Restarts/stops game music
        DontDestroyAudio.Instance.gameObject.GetComponent<AudioSource>().Stop();
    }

    // Changes the volume to the value set by the slider
    public void ChangeVolume() {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    // Loads the 'musicVolume' PlayerPref from previous session
    private void Load() {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    // Saves the volume from the slider to the PlayerPrefs 'musicVolume'
    private void Save() {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    // Quits the game
    public void QuitGame() {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
