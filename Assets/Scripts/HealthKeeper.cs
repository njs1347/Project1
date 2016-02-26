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
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (0,255,0,255);
		}
		if (playerHP == 4) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (128,255,0,255);
		}
		if (playerHP == 3) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (255,255,0,255);
		}
		if (playerHP == 2) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (255,128,0,255);
		}
		if (playerHP == 1) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (255,0,0,255);
		}
		if (playerHP == 0) {
			healthText.gameObject.GetComponent<GUIText> ().color = new Color32 (255,0,0,255);
		}

		healthText.text = "Health: " + playerHP + "/5";
	}

}
