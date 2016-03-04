using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public GameObject PlayerBullet;
	public GameObject BulletPosition;
	private HealthKeeper healthKeeper;
	private SpawnerScript spawnerScript;
	public GUIText youLoseText;

	public float playerHealth = 5.0f;

	Vector3 mousePosition;
	Vector3 direction;

	private GameObject PlayAgain;



	public float speed = 10.0f;

	void Start ()
	{
		GameObject playerHealthObject = GameObject.FindWithTag ("HealthKeeper");
		if (playerHealthObject != null) {
			healthKeeper = playerHealthObject.GetComponent <HealthKeeper> ();
		}
		if (healthKeeper == null) {
			Debug.Log ("Can't find 'HealthKeeper' script");
		}

		spawnerScript = GetComponent<SpawnerScript> ();
		PlayAgainButton ();

	}

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

		if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey("a"))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		 if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey("d"))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		 if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey("w"))
		{
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		 if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey("s"))
		{
			transform.position += Vector3.down * speed * Time.deltaTime;
		}




		if (playerHealth <= 0) {
			youLoseText.text = "YOU LOSE";
			Destroy (gameObject);
			print ("you lose");
			//youLoseText.enabled = true;
			PlayAgain.SetActive (true);

		}

		//OUT OF BOUNDS CHECK
		if (transform.position.x > 15f) {
			transform.position = new Vector3(15f,transform.position.y,0);
		}
		if (transform.position.x < -15f) {
			transform.position = new Vector3(-15f,transform.position.y,0);
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
		healthKeeper.SubtractOneHealth ();

		if (playerHealth == 4) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.21f, 0.9f, 0.21f, 1);
		}
		if (playerHealth == 3) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.45f, 0.86f, 0.45f, 1);
		}
		if (playerHealth == 2) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.67f, 0.9f, 0.67f, 1);
		}
		if (playerHealth == 1) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
		}

	}

	void PlayAgainButton()
	{
		PlayAgain = GameObject.Find ("GameManager").GetComponent<GameManagers> ().PlayAgain;
		PlayAgain.GetComponent<Button> ().onClick.AddListener (GameOverCommence);
	}

	public void LoadScene(int level)
	{
		//loadingImage.SetActive(true);
		Application.LoadLevel(level);
	}

	void GameOverCommence()
	{
		spawnerScript.SpawnerReset ();
	}
}
