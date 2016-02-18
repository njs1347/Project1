using UnityEngine;
using System.Collections;

public class PlayerBulletScript : MonoBehaviour {

	float speed;
	public Vector3 buldirection = Vector3.zero;
	public float rotateTo = 0;

	// Use this for initialization
	void Start () {

		speed = 10f;
		//print (rotateTo);
		transform.Rotate (0,0,rotateTo);

		Destroy (gameObject, 6f);
	
	}
	
	// Update is called once per frame
	void Update () {

		/*Vector2 position = transform.position;

		position = new Vector2 (position.x, position.y + speed * Time.deltaTime);

		transform.position = position;

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));*/

		//transform.Rotate (buldirection);
		transform.position += buldirection * speed * Time.deltaTime;
		/*if (transform.position.y > max.y) {

			Destroy (gameObject);

		}*/
	
	}
}
