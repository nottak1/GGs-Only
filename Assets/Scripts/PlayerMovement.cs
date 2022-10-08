using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    // Update is called once per frame
    void FixedUpdate() {
        // Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if(Input.GetKey("d")) {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(Input.GetKey("a")) {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Checks to see if user falls off the edge
        if(rb.position.y < -1f) {
            FindObjectOfType<GameManager>().EndGame();
        }

        // if (Input.GetKey("n")) {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // }
    }

}
