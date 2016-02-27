using UnityEngine;
using System.Collections;

public class BomberScript : MonoBehaviour {
	public GameObject bullet;
	Vector3 bulDirection;
	bool canIShoot = true;

	float TimeSpawned;
	float shootTimer;
	// Use this for initialization
	void Start () {
		TimeSpawned = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (shootTimer + 2.25f < Time.time && canIShoot) {
			
			for (int x = 0; x < 6; x++) {
				for (int y = 0; y < 6; y++) {


					Instantiate (bullet, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);

					bulDirection = new Vector3(x*.2f,y*.2f,0);
					print (bulDirection);

					bullet.GetComponent<EnemyBulletScript> ().targetPos = bulDirection;
				}

			}
			shootTimer = Time.time;
		}

	}
}
