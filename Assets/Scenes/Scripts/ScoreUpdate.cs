using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
	public Transform player;
	public Text score;
	public Text hiscore;
	public Text newHigh;

	public int highscore;
	bool highscoreAchieved = false;

    void Start() {
    	highscore = PlayerPrefs.GetInt("hi");
    	hiscore.text = "High Score: " + highscore.ToString();
    }

    void Update()
    {
        score.text = player.position.z.ToString("0");

        if (player.position.z > highscore) {
        	highscore = (int) player.position.z;
        	highscoreAchieved = true;
        }
    }

    public bool ProclaimHighScore() {
    	Debug.Log(highscore);
    	if (highscoreAchieved) {
    		PlayerPrefs.SetInt("hi", highscore);
    		GetComponent<AudioSource>().Play();
    		newHigh.text = "New High Score!";
    	}
    	return highscoreAchieved;
    }
}
