using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
	public GameObject player;

	void Start() { 
		player = GameObject.Find("Player");
	}

    void Update()
    {
        if (transform.position.z < player.transform.position.z - 10 || transform.position.y > 1.8) {
        	Destroy(gameObject);
        }
    }
}
