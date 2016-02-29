using UnityEngine;
using System.Collections;

public class BomberScript : MonoBehaviour {
	public GameObject bullet;
	Vector3 bulDirection = new Vector3(.4f,.4f,0);
	bool canIShoot = true;

	float TimeSpawned;
	float shootTimer;


	public int scoreValue;
	private ScoreKeeper scoreKeeper;
	float enemyHealth = 3;


	// Use this for initialization
	void Start () {
		TimeSpawned = Time.time;

		GameObject scoreKeeperObject = GameObject.FindWithTag ("ScoreKeeper");
		if (scoreKeeperObject != null) {
			scoreKeeper = scoreKeeperObject.GetComponent <ScoreKeeper> ();
		}
		if (scoreKeeper == null) {
			Debug.Log ("Can't find 'ScoreKeeper' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (shootTimer + 4f < Time.time && canIShoot) {
			
		
					Instantiate (bullet, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);

					bulDirection = new Vector3(.4f,.4f,0);
					print ("pos pos" + bulDirection);

					bullet.GetComponent<EnemyBulletScript> ().targetPos = bulDirection;
	

		
					Instantiate (bullet, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);

					bulDirection = new Vector3(-.4f,.4f,0);
					print ("neg pos"+bulDirection);

					bullet.GetComponent<EnemyBulletScript> ().targetPos = bulDirection;


		
					Instantiate (bullet, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);

					bulDirection = new Vector3(.4f,-.4f,0);
					print ("pos neg" + bulDirection);

					bullet.GetComponent<EnemyBulletScript> ().targetPos = bulDirection;



					Instantiate (bullet, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);

					bulDirection = new Vector3(-.4f,-.4f,0);

					print ("neg neg" + bulDirection);

					bullet.GetComponent<EnemyBulletScript> ().targetPos = bulDirection;



			shootTimer = Time.time;
		}

		//delete here
		if (enemyHealth <= 0) { 
			Destroy (gameObject);
		}

		if (transform.position.y < -10f) {
			Destroy (gameObject);
		}

	}



	void OnCollisionEnter2D(Collision2D coll){						// when hit by playerBullet
		if (coll.gameObject.tag == "PlayerBullet") {
			onHit ();
		}
		if (coll.gameObject.tag == "Player") {
			enemyHealth = 0;
		}
	}

	void onHit ()
	{
		if (enemyHealth <= 1) {
			scoreKeeper.AddScore ();

		}
		enemyHealth--;

		if (enemyHealth == 2) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 0.5f, 0, 1);
		}

		if (enemyHealth == 1) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0, 1);
		}
	}
}
