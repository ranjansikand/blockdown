using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
	bool gameEnded = false;
	public float restartDelay = 2.5f;
	bool quitPressed = false;

	public Text game;
	public Text over;

	void Start() {
		GetComponent<AudioSource>().Play();
	}


	public void GameOver() {
		if (!(gameEnded)) {
			gameEnded = true;
			Debug.Log("Game Over!");

			Invoke("GameTextAppear", 1.1f);
			Invoke("OverTextAppear", 1.5f);

			GetComponent<AudioSource>().Stop();

			FindObjectOfType<ScoreUpdate>().ProclaimHighScore();

			Invoke("Restart", restartDelay);
		}
	}

	void Restart() {
		SceneManager.LoadScene("Play");
	}

	void GameTextAppear() {
		game.text = "GAME";
		FindObjectOfType<TextScript>().PlaySound();
	}
	void OverTextAppear() {
		over.text = "OVER";
		FindObjectOfType<TextScript>().PlaySound();
	}

	void Update()
    {
        if (Input.GetKey("escape") && !(quitPressed)) {
        	Debug.Log("Quit");
        	// switch to change scene -- start
        	quitPressed = true;
        	SceneManager.LoadScene("StartMenu");
        }
    }
}
