using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {
	int spawnNumber = 1;
	float spawnTimer = 2;
	public GameObject triangle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > spawnTimer) {
			spawnTimer += 2;
			if (spawnNumber == 1) {
				//SPAWN TRIANGLE ENEMY
				//GameObject triangle = new GameObject(Random.Range(-8,8),9);
				Instantiate(triangle,
					new Vector3(Random.Range(-8,8),9,0),
					Quaternion.identity);
			}

		}
	}
}
