using UnityEngine;
using System.Collections;

public class HealthKeeper : MonoBehaviour {

	public GUIText healthText;
	public int playerHP = 5;

	void Start () 
	{
		UpdateHealth ();
	}

	public void SubtractOneHealth()
	{
		playerHP--;
		if (playerHP <= 0) 
		{
			playerHP = 0;
		}
		UpdateHealth ();
	}

	void UpdateHealth()
	{
		if (playerHP == 5) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (55, 230, 55, 255);
		}
		if (playerHP == 4) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (115, 235, 115, 255);
		}
		if (playerHP == 3) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (145, 240, 145, 255);
		}
		if (playerHP == 2) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (175, 245, 175, 255);
		}
		if (playerHP == 1) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (210, 250, 210, 255);
		}
		if (playerHP == 0) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (255, 255, 255, 255);
		}

		healthText.text = "Health: " + playerHP + "/5";
	}

}
