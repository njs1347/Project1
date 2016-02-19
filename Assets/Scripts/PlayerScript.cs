using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public GameObject PlayerBullet;
	public GameObject BulletPosition;

	public float playerHealth = 5.0f;

	Vector3 mousePosition;
	Vector3 direction;



	public float speed = 10.0f;
	
	void Update ()
	{
		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
		if (Input.GetButtonDown("Fire1")) {

			GameObject bul = (GameObject)Instantiate (PlayerBullet);
			bul.transform.position = transform.position;

			mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePosition.z = 0.0f;
			direction = (mousePosition - transform.position).normalized;
			bul.GetComponent<PlayerBulletScript> ().buldirection = direction;

		}

		Quaternion rotation = Quaternion.LookRotation
			(mousePosition - transform.position, transform.TransformDirection(Vector3.up));
		transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += Vector3.down * speed * Time.deltaTime;
		}


		if (playerHealth == 0) {
			Destroy (gameObject);
			print ("you lose");
		}

		//OUT OF BOUNDS CHECK
		if (transform.position.x > 18f) {
			transform.position = new Vector3(18f,transform.position.y,0);
		}
		if (transform.position.x < -18f) {
			transform.position = new Vector3(-18f,transform.position.y,0);
		}
		if (transform.position.y > 8f) {
			transform.position = new Vector3(transform.position.x,8f,0);
		}
		if (transform.position.y < -8f) {
			transform.position = new Vector3(transform.position.x,-8f,0);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Enemy") {		//when hit by enemy
			onHit ();
			onHit ();	//loss 2 hp for enemy collision
		}

		if (coll.gameObject.tag == "EnemyBullet") {	//when hit by enemy bullet
			onHit ();
		}
	}

	void onHit (){
		playerHealth--;
	}
}
