using UnityEngine;
using System.Collections;

public class EnemyBulletScript : MonoBehaviour {
	public float speed = .5f;
	public Vector3 targetPos;
	bool left = false;
	bool up = false;
	// Use this for initialization
	void Start () {
		gameObject.transform.LookAt (targetPos);
		if (targetPos.y > transform.position.y) {
			up = true;
		} 
		else {
			up = false;
		}

		if (targetPos.x > transform.position.x) {
			left = false;
		}

		else {
			left = true;
		}
		//transform.Rotation =  Quaternion.Euler(new Vector3(0,0,));
		transform.rotation = Quaternion.Euler(new Vector3(0,0, transform.rotation.z));
	}
	
	// Update is called once per frame
	void Update () {
		if (left) {
			transform.Translate (-Time.deltaTime *speed,0,0);
		}
		else{transform.Translate (Time.deltaTime *speed,0,0);}

		if (!up) {
			transform.Translate (0, -Time.deltaTime * speed, 0);
		} 
		else {
			transform.Translate (0, Time.deltaTime * speed, 0);
		}

	}
}
