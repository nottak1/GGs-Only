using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    // private AudioSource audioSource;
    // public GameObject objectMusic;

    public void StartGame() {
        Debug.Log("started");
        DontDestroyAudio.Instance.gameObject.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.visible = false;
        TimeController.instance.BeginTimer();

        // Restarts the background music
        // objectMusic = GameObject.FindWithTag("GameMusic");
        // audioSource = objectMusic.GetComponent<AudioSource>();
        // audioSource.Play();
    }

    // Quits the game
    public void QuitGame() {
        Debug.Log("Quitting game");
        Application.Quit();
    }

}
