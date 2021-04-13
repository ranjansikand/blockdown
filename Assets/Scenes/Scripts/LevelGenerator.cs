using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
	public GameObject block;
	public GameObject[] powerups;

	public Transform player;
	public Vector3 offset;
	public int powerChance = 3;
	// indicates 30% chance

	// Use this for initialization
	void Start () {
		// level generation coroutine
		StartCoroutine(SpawnBlocks());
	}

	// Update is called once per frame
	void Update () {
		transform.position = player.position + offset;
	}

	IEnumerator SpawnBlocks() {
		float upperValue = 0.8f;
		int maxBlocks = 4;
		if (player.position.z > 1000 && player.position.z < 1999) {
			upperValue = 0.6f;
		}
		else if (player.position.z > 2000 && player.position.z < 3499) {
			upperValue = 0.4f;
			maxBlocks = 5;
		}
		else if (player.position.z > 3500 && player.position.z < 7499) {
			upperValue = 0.3f;
			
		} else if (player.position.z > 7500) {
			upperValue = 0.2f;
			maxBlocks = 6;
		}

		while (true) {

			int blocksThisRow = Random.Range(0, maxBlocks);

			for (int i = 0; i < blocksThisRow; i++) {
				Instantiate(block, new Vector3(Random.Range(-9.5f, 9.5f), 1.1f, transform.position.z), Quaternion.identity);
			}

			if (blocksThisRow == 0) {
				if (Random.Range(1, 10) < powerChance) {
					Instantiate(powerups[Random.Range(0, powerups.Length)], new Vector3(Random.Range(-9.5f, 9.5f), 1.25f, transform.position.z), Quaternion.identity);
				}
			}
			yield return new WaitForSeconds(Random.Range(0.08f, upperValue));
		}
	}
}
