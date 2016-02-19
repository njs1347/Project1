using UnityEngine;
using System.Collections;

public class TriangleScript : MonoBehaviour {
	int pathNum;
	float currentPos;
	float speed = 4f;
	float rotationSpeed = 1.5f;
	Vector2 position;

	float enemyHealth = 3;

	public GameObject bullet;

	float TimeSpawned;
	float shootTimer;

	bool canIShoot = true;
	public Transform corner1;
	public Transform corner2;
	public Transform corner3;

	public EnemyBulletScript bulScript;
	Vector3 bulDirection;

	public int scoreValue;
	private ScoreKeeper scoreKeeper;


	// Use this for initialization
	void Start () {
		
		pathNum = Random.Range (1,9);
		//pathNum = 8;
		TimeSpawned = Time.time;
		shootTimer = Time.time;
		//corner1 = Transform.FindChild ("top");
		//corner2 = Transform.FindChild ("left");
		//corner3 = Transform.FindChild ("right");
		corner1 = transform.FindChild ("top");
		corner2 = transform.FindChild ("left");
		corner3 = transform.FindChild ("right");
		if (pathNum == 1) {
			
			speed = 5f;
		}
		if (pathNum == 2) {
			transform.position = new Vector2(12,7);
			speed = 3f;
		}
		if (pathNum == 3) {
			transform.position = new Vector2(10,7);
			speed = 6f;
		}
		if (pathNum == 4) {
			transform.position = new Vector2(-10,-10.5f);
			speed = 6f;
		}

		//topleft to botright
		if (pathNum == 5) {
			transform.position = new Vector2 (-19,9);
		}
		//botright to top left
		if (pathNum == 6) {
			transform.position = new Vector2 (19,-9);
		}

		if (pathNum == 7) {
			transform.position = new Vector2 (19,9);
		}

		if (pathNum == 8) {
			transform.position = new Vector2 (-19,-9);
		}

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

		//ENEMY PATHING
		//Straight down
		if (pathNum == 1) {
			gameObject.transform.position = new Vector2(transform.position.x,transform.position.y - speed * Time.deltaTime);
		}

		//V shaped from top
		if (pathNum == 2) {
			if(transform.position.x>0f)
			{
				transform.position = new Vector2(transform.position.x-speed*Time.deltaTime*2,transform.position.y-speed*Time.deltaTime);
			}
			if(transform.position.x<=0f){
				transform.position = new Vector2(transform.position.x-speed*Time.deltaTime*2,transform.position.y+speed*Time.deltaTime);
				if(transform.position.x<-20){Destroy (gameObject);}
			}

		}
		//top right L to the left
		if (pathNum == 3) {
			if (transform.position.y > 0) {
				transform.position = new Vector2(transform.position.x,transform.position.y-speed*Time.deltaTime);
			}
			if (transform.position.y <= 0) {
				transform.position = new Vector2(transform.position.x-speed*Time.deltaTime,transform.position.y);
				if(transform.position.x<-20){Destroy (gameObject);}
			}
		}
		//bot left L to the right
		if (pathNum == 4) {
			if (transform.position.y < 0) {
				transform.position = new Vector2(transform.position.x,transform.position.y+speed*Time.deltaTime);
			}
			if (transform.position.y >= 0) {
				transform.position = new Vector2(transform.position.x+speed*Time.deltaTime,transform.position.y);
				if(transform.position.x>20){Destroy (gameObject);}
			}
		}
		//top left to botright
		if (pathNum == 5) {
			transform.position = new Vector2(transform.position.x+speed*Time.deltaTime*1.5f,transform.position.y-speed*Time.deltaTime);
		}
		//bot right to top left
		if (pathNum == 6) {
			transform.position = new Vector2(transform.position.x-speed*Time.deltaTime*1.5f,transform.position.y+speed*Time.deltaTime);
		}
		//top right to bot left
		if (pathNum == 7) {
			transform.position = new Vector2(transform.position.x-speed*Time.deltaTime*1.5f,transform.position.y-speed*Time.deltaTime);
		}
		//bot left to top right
		if (pathNum == 8) {
			transform.position = new Vector2(transform.position.x+speed*Time.deltaTime*1.5f,transform.position.y+speed*Time.deltaTime);
		}


		gameObject.transform.Rotate (new Vector3(0,0,rotationSpeed));

		//ENEMY SHOOTING
		if (shootTimer + 1.5f < Time.time && canIShoot) {
			for(int i = 0;i<3;i++){
				Instantiate (bullet, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
				if (i == 0) {
					//bullet.transform.LookAt(corner1.transform);
					bulDirection = (corner1.transform.position - transform.position).normalized;
					bullet.GetComponent<EnemyBulletScript> ().targetPos = bulDirection;
				}
				else if (i == 1) {
					//bullet.transform.LookAt(corner2.transform);
					//bullet.GetComponent<EnemyBulletScript>().targetPos = corner2.transform.position;
					bulDirection = (corner2.transform.position - transform.position).normalized;
					bullet.GetComponent<EnemyBulletScript> ().targetPos = bulDirection;
				}
				else if(i==2){
					//bullet.transform.LookAt(corner3.transform);
					//bullet.GetComponent<EnemyBulletScript>().targetPos = corner3.transform.position;
					//bullet.GetComponent<EnemyBulletScript> ().targetPos.x = bullet.GetComponent<EnemyBulletScript> ().targetPos.x * -1;
					//bullet.GetComponent<EnemyBulletScript> ().speed = -bullet.GetComponent<EnemyBulletScript> ().speed;

					bulDirection = (corner3.transform.position - transform.position).normalized;
					bullet.GetComponent<EnemyBulletScript> ().targetPos = bulDirection;
				}
			}

			shootTimer = Time.time;
		}
		/*if (((Time.time-TimeSpawned)+1.6)%1.6 == 0) {
			canIShoot = true;
		}*/


		//DESTROY CHECKS
		if (enemyHealth == 0) { 
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

	}
}
