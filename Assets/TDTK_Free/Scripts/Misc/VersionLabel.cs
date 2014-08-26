using UnityEngine;
using System.Collections;

public class VersionLabel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		GUI.contentColor = Color.black;

		GUI.Label(new Rect(0, Screen.height-25, 200, 25), "By: Team Gamesaurus Rex");
	}
}
