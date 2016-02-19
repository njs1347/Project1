﻿using UnityEngine;
using System.Collections;

public class PlayerBulletScript : MonoBehaviour {

	float speed;

	// Use this for initialization
	void Start () {

		speed = 10f;
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 position = transform.position;

		position = new Vector2 (position.x, position.y + speed * Time.deltaTime);

		transform.position = position;

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		if (transform.position.y > max.y) {

			Destroy (gameObject);

		}
	
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "EnemyBullet" || coll.gameObject.tag == "Enemy") {
			Destroy (gameObject);
		}
	}
}
