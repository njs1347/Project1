using UnityEngine;
using System.Collections;

public class TriangleScript : MonoBehaviour {
	int pathNum;
	float currentPos;
	float speed = .10f;
	float rotationSpeed = 1.5f;
	Vector2 position;

	float health = 3;

	public GameObject bullet;

	float TimeSpawned;

	bool canIShoot = true;
	public Transform corner1;
	public Transform corner2;
	public Transform corner3;

	public EnemyBulletScript bulScript;


	// Use this for initialization
	void Start () {
		pathNum = 1;
		TimeSpawned = Time.time;
		//corner1 = Transform.FindChild ("top");
		//corner2 = Transform.FindChild ("left");
		//corner3 = Transform.FindChild ("right");
		corner1 = transform.FindChild ("top");
		corner2 = transform.FindChild ("left");
		corner3 = transform.FindChild ("right");

	}
	
	// Update is called once per frame
	void Update () {
		

		//ENEMY PATHING
		if (pathNum == 1) {
			currentPos = gameObject.transform.position.y;
			currentPos -= speed;

			gameObject.transform.position = new Vector2(transform.position.x,currentPos);
		}
		gameObject.transform.Rotate (new Vector3(0,0,rotationSpeed));

		//ENEMY SHOOTING
		if (TimeSpawned + 1 < Time.time && canIShoot) {
			for(int i = 0;i<3;i++){
				Instantiate (bullet, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
				if (i == 0) {
					//bullet.transform.LookAt(corner1.transform);
					bullet.GetComponent<EnemyBulletScript>().targetPos = corner1.transform.position;
				}
				else if (i == 1) {
					//bullet.transform.LookAt(corner2.transform);
					bullet.GetComponent<EnemyBulletScript>().targetPos = corner2.transform.position;
				}
				else if(i==2){
					//bullet.transform.LookAt(corner3.transform);
					bullet.GetComponent<EnemyBulletScript>().targetPos = corner3.transform.position;
					//bullet.GetComponent<EnemyBulletScript> ().targetPos.x = bullet.GetComponent<EnemyBulletScript> ().targetPos.x * -1;
					//bullet.GetComponent<EnemyBulletScript> ().speed = -bullet.GetComponent<EnemyBulletScript> ().speed;
				}
			}
			canIShoot = false;
		}

		//DESTROY CHECKS
		if (health == 0) {Destroy (gameObject);}

		if (transform.position.y < -10f) {
			Destroy (gameObject);
		}
	}


	void onHit ()
	{
		health--;
	}
}
