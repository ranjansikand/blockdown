using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    	int highscore = PlayerPrefs.GetInt("hi");
        GetComponent<Text>().text = "High Score: " + highscore.ToString();
    }
}
