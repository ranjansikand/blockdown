using UnityEngine;
using UnityEngine.UI;

public class CollisionBehavior : MonoBehaviour
{
	public PlayerMovement movement;
	bool playerInvincible = false;

	public Text Shield;

	//public AudioSource powersound;

	void Start() {
		Shield.text = "";
		//jumpPower = GameObject.Find("JumpPower");
	}

    void OnCollisionEnter(Collision collidedObj) {
    	if (collidedObj.collider.tag == "Obstacle") {
    		Debug.Log("Obstacle hit!");
    		
    		if (playerInvincible) {
    			playerInvincible = false;
    			Debug.Log("Invincibility removed");
    			Shield.text = "";
    		}
    		else {
	    		movement.enabled = false;
	    		FindObjectOfType<ManagerScript>().GameOver();
    		}
    	}
    }

    void OnTriggerEnter(Collider other) {
    	if (other.GetComponent<Collider>().tag == "ShieldPowerUp") {
    		other.gameObject.SetActive(false);
    		// make the powerup disappear
    		Shield.text = "Shield Active";

    		GetComponent<AudioSource>().Play();

    		playerInvincible = true;
    		Debug.Log("Player Invincible");
    	}
    	else if (other.GetComponent<Collider>().tag == "JumpPowerUp") {
    		FindObjectOfType<JumpScript>().PlaySound();
    		Debug.Log("Jump Activated");
    		FindObjectOfType<PlayerMovement>().ActivateJump();

    		FindObjectOfType<JumpScript>().hideObject();
    	} 
    	else if (other.GetComponent<Collider>().tag == "SlowMoPowerUp") {
    		FindObjectOfType<SlowScript>().hideObject();
    		FindObjectOfType<SlowScript>().PlaySound();
    		Debug.Log("Slow Mo Activated");
    		FindObjectOfType<PlayerMovement>().SlowMotion();
    	}
    }
}
