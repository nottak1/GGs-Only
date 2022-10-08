using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// using Firebase.Database;
// using Firebase.Auth;
// using Firebase;
// using Firebase.Unity;

public class Credits : MonoBehaviour {

    public Text finalTime;

    // Name the user inputs for the leaderboard in Text
    public Text userName;

    // String for name - Leaderboard
    private string userNameStr;

    public GameObject nameSubmitUI;

    public GameObject finalScreenUI;


    void Start() {
        // Sets the final score/time to the finalTime Text
        finalTime.text = TimeController.instance.timeCounter.text;
        Cursor.visible = true;
    }

    void Update() {
        Cursor.visible = true;
        // Debug.Log("cursor stuff");
    }
    public void Quit() {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void PlayAgain() {
        SceneManager.LoadScene("Menu");
        TimeController.instance.EndTimer();

        // Restarts/stops game music
        DontDestroyAudio.Instance.gameObject.GetComponent<AudioSource>().Stop();
    }

    // On Submit Button request
    public void SubmitName() {
        
        nameSubmitUI.SetActive(false);
        finalScreenUI.SetActive(true);
        userNameStr = userName.text.ToString();
        Debug.Log(userNameStr);
    }

    /**
    FIREBASE STUFF
    */

}
