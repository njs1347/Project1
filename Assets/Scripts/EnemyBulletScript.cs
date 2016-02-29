using UnityEngine;
using System.Collections;

public class EnemyBulletScript : MonoBehaviour {
	public float speed = 1f;
	public Vector3 targetPos;
	bool left = false;
	bool up = false;
	private ScoreKeeper scoreKeeper;

	// Use this for initialization
	void Start () {
		/*if (targetPos.y < transform.position.y) {
			//targetPos.y = targetPos.y * -1;
			speed = -speed;
		}
		//2D Equivalent to LookAt();
		Quaternion rotation = Quaternion.LookRotation
			(targetPos - transform.position, transform.TransformDirection(Vector3.up));
		transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);*/

		print ("bullet target " + targetPos);

		GameObject scoreKeeperObject = GameObject.FindWithTag ("ScoreKeeper");
		if (scoreKeeperObject != null) {
			scoreKeeper = scoreKeeperObject.GetComponent <ScoreKeeper> ();
		}
		if (scoreKeeper == null) {
			Debug.Log ("Can't find 'ScoreKeeper' script");
		}

		Destroy(gameObject, 5f);

	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position += targetPos * speed * Time.deltaTime;

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
		if (coll.gameObject.tag == "PlayerBullet") {
			scoreKeeper.AddScoreSmall ();
			Destroy (gameObject);

		}

	}
}
