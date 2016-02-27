using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {
	//Which enemy to spawn
	int spawnNumber = 1;

	//Time counter for spawns
	float spawnTimer = 2;
	//Interval at which to spawn them
	float spawnCooldown = 2;

	//Objects to reference
	public GameObject triangle;
	public GameObject bomber;
	public GameObject ScoreKeeper;

	//score from scorekeeper
	int score;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		score = ScoreKeeper.GetComponent<ScoreKeeper>().score;
		if (score >= 500 && score<749) {
			spawnCooldown = 1.50f;
		}
		if (score >= 750 && score<999) {
			spawnCooldown = 1.25f;
		}
		if (score >= 1000 && score<1999) {
			spawnCooldown = 1f;
		}
		if (score >= 2000 && score<2999) {
			spawnCooldown = .75f;
		}
		if (score >= 3000 && score<3999) {
			spawnCooldown = .50f;
		}
		if (score >= 4000) {
			spawnCooldown = .25f;
		}



		if (Time.time > spawnTimer) {
			spawnTimer += spawnCooldown;
			if (spawnNumber == 1) {
				//SPAWN TRIANGLE ENEMY
				//GameObject triangle = new GameObject(Random.Range(-8,8),9);
				Instantiate(triangle,
					new Vector3(Random.Range(-8,8),9,0),
					Quaternion.identity);
				
			}

			if (spawnNumber == 2) {
				//SPAWN BOMBER ENEMY
				//GameObject triangle = new GameObject(Random.Range(-8,8),9);
				Instantiate(bomber,
					new Vector3(Random.Range(-8,8),Random.Range(-9,9),0),
					Quaternion.identity);

			}

		}
	}
}
