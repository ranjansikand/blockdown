using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sideForce = 500f;
    public float jumpForce = 2000f;

    public float slowMod = 0.25f;
    public float slowMoDuration = 3f;
    bool slowActive = false;

    float speedSaver;
    float sideSpeedSaver;
    float displayText;

    public Text SlowMoTimer;

    void Start() {
        speedSaver = forwardForce;
        sideSpeedSaver = sideForce;
        SlowMoTimer.text = "";

        displayText = slowMoDuration;
    }

    void FixedUpdate() {
        rb.AddForce(0,0,forwardForce * Time.deltaTime);

        if (Input.GetKey("d") || Input.GetKey("right")) {

        	// right motion input
        	rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

		} else if (Input.GetKey("a") || Input.GetKey("left")) {

			// left motion input
			rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

		}

        if (rb.position.y < -2f) {
            FindObjectOfType<ManagerScript>().GameOver();
        }

        if (slowActive) {
            displayText -= Time.deltaTime;
            SlowMoTimer.text = displayText.ToString("0");
        } else {
            displayText = slowMoDuration;
            SlowMoTimer.text = "";
        }


    }

    public void ActivateJump() {
        rb.AddForce(0,jumpForce,0);
        Debug.Log("JUMPING!");
    }

    public void SlowMotion() {
        forwardForce = forwardForce * slowMod;
        sideForce = sideForce * slowMod;
        slowActive = true;

        Invoke("StopSlowMo", slowMoDuration);
    }

    public void StopSlowMo() {
        forwardForce = speedSaver;
        sideForce = sideSpeedSaver;
        SlowMoTimer.text = "";
        slowActive = false;
    }
}
