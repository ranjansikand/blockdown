using UnityEngine;

public class TextScript : MonoBehaviour
{
    public void PlaySound() {
    	GetComponent<AudioSource>().Play();
    }

}
