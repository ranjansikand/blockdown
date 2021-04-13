using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public GameObject powerUp;
    public Vector3 offset;
    public void PlaySound() {
    	powerUp.GetComponent<AudioSource>().Play();
    }
    public void hideObject() {
        powerUp.transform.position = powerUp.transform.position + offset;
    }
}
