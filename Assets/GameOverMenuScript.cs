using UnityEngine;
using System.Collections;

public class GameOverMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Label(new Rect(100,100, 400,200),"Game Over");
		if(GUI.Button(new Rect(150,150,150,100),"Play again"))
		   	{
			Application.LoadLevel("BalloonFightScene");
			}
	}
}
