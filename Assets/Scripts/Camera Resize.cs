using UnityEngine;
using System.Collections;

public class CameraResize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera.main.orthographicSize = 42f * Screen.height / Screen.width * 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
