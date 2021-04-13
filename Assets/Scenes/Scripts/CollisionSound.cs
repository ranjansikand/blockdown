using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
	public AudioSource sound;
	public GameObject player;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
    }

    void OnCollisionEnter(Collision collidedObj) {
    	if (!(collidedObj.collider.tag == "Ground")) {
    		if (transform.position.z < player.transform.position.z + 50) {
    			GetComponent<AudioSource>().Play();
    		}
    	}
    }
}
