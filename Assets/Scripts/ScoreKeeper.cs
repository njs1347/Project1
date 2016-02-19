using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	public GUIText scoreText;
	private int score;


	// Use this for initialization
	void Start () {

		UpdateScore ();
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void AddScore()
	{

		print (score);
		score  +=50;
		UpdateScore ();
		print (score);
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}
}
