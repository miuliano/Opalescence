using UnityEngine;
using System.Collections;

public class DemoMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnGUI(){

		/*
		GUI.backgroundColor = Color.white;

		if(GUI.Button(new Rect(Screen.width/2-75, Screen.height/2, 150, 30), Resources.Load("StartButton") as Texture)){
			Application.LoadLevel("ROM Scene");
		}
		
		*/

		if(Input.GetMouseButtonDown(0))
			Application.LoadLevel("ROM Scene");
		if(Input.GetMouseButtonDown(1))
			Application.LoadLevel("ROM Scene");
		if(Input.GetMouseButtonDown(2))
			Application.LoadLevel("ROM Scene");


		
		
		/*
		var StartButton : Texture;
		GUI.DrawTexture(Rect(10,10,60,60), StartButton, ScaleMode.ScaleToFit, true, 10.0f);S
		Application.LoadLevel("ROM Scene");
		*/

		/*
		GUI.contentColor = Color.white;

		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		centeredStyle.fontSize=24;


		GUI.Label(new Rect(Screen.width/2-150, Screen.height-200, 300, 150), "" +
		          "<size=25>Instructions:</size>\n\n" +
		          "<size=14>Place a gemstone tower anywhere on the grid.</size>\n" +
		          "<size=14>The objective is to erode all the ores.</size>\n\n", centeredStyle);
		*/

		/*
		if(GUI.Button(new Rect(Screen.width/2-50, Screen.height/2-30+45, 100, 30), "Level 2")){
			Application.LoadLevel("ExampleScene2");
		}
		if(GUI.Button(new Rect(Screen.width/2-50, Screen.height/2-30+90, 100, 30), "Level 3")){
			Application.LoadLevel("ExampleScene3");
		}
		*/
		//~ if(GUI.Button(new Rect(Screen.width/2-50, Screen.height/2-80+135, 100, 30), "Demo 4")){
			//~ Application.LoadLevel("ExampleScene4");
		//~ }
		//~ if(GUI.Button(new Rect(Screen.width/2-50, Screen.height/2-80+180, 100, 30), "Demo 1 nGUI")){
			//~ Application.LoadLevel("ExampleScene1(nGUI)");
		//~ }
		//~ if(GUI.Button(new Rect(Screen.width/2-50, Screen.height/2-80+225, 100, 30), "Demo 2 nGUI")){
			//~ Application.LoadLevel("ExampleScene2(nGUI)");
		//~ }
	}
}
