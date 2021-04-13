using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
	bool quitPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKey("escape") && !(quitPressed)) {
        	Debug.Log("Quit");
        	quitPressed = true;
        	Application.Quit();
        }

        if (Input.GetKey("space")) {
        	Debug.Log("Start Game");
    
        	SceneManager.LoadScene("Play");
        }
    }
}
