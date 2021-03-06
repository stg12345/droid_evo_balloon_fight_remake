﻿using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	public Camera camera;
	Vector2 bottomLeft;
	Vector2 topRight;
	Rect cameraRect;
	int rotationval;
	public int android_jumpval;
	public int android_strafeval;
	public Rect windowrect;
	bool grounded;
	public int recoilvectorX;
	// Use this for initialization
	void Start () {
		bottomLeft = camera.ScreenToWorldPoint(Vector2.zero);
		topRight = camera.ScreenToWorldPoint(new Vector2(
			camera.pixelWidth, camera.pixelHeight));
		cameraRect = new Rect(
			bottomLeft.x,
			bottomLeft.y,
			topRight.x - bottomLeft.x,
			topRight.y - bottomLeft.y);

		//Set jump acceleration value
		android_jumpval = 40;
		android_strafeval = 10;

		//set recoil vector for x
		//recoilvectorX = 100;
	}

	void Update()
	{
			

			/*transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, cameraRect .xMin, cameraRect .xMax),
			Mathf.Clamp(transform.position.y, cameraRect .yMin, cameraRect .yMax),
			transform.position.z);*/
	}

	// Update is called once per frame
	void FixedUpdate () {

#if UNITY_EDITOR_WIN
		if(Input.GetButton("Jump"))
		{
			//Debug.Log(transform.position.y);
			//if(transform.position.y < camera.pixelHeight)
		{	
			this.rigidbody2D.AddForce(new Vector2(0,1) * 5);
			//Debug.Log("Jumping :" + rigidbody2D.velocity.magnitude);
		}
		}
		if(Input.GetAxis("Horizontal")!=0.0)
		{
			this.rigidbody2D.AddForce(new Vector2(1,0) * Input.GetAxis("Horizontal")*2);
			//Debug.Log("axis :"+ Input.GetAxis("Horizontal"));
		}
#endif

		if(transform.position.x > cameraRect.xMax)
		{
			this.transform.position = new Vector2(cameraRect.xMin, this.transform.position.y);
		}

		if(transform.position.x < cameraRect.xMin)
		{
			this.transform.position = new Vector2(cameraRect.xMax, this.transform.position.y);
		}


	}

		void OnGUI()
		{
			if(GUI.Button(new Rect(10,(Screen.height - (Screen.height * 0.2f)),200,80),"Jump"))
			{
			this.rigidbody2D.AddForce(new Vector2(0,1) * android_jumpval);
			}

			if(GUI.Button(new Rect(250,(Screen.height - (Screen.height * 0.2f)),200,80),"Left"))
		{
			this.rigidbody2D.AddForce(new Vector2(-1,0) * android_strafeval);
		}

		if(GUI.Button(new Rect(500,(Screen.height - (Screen.height * 0.2f)),200,80),"Right"))
		{
			this.rigidbody2D.AddForce(new Vector2(1,0) * android_strafeval);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log(other.collider.tag);
		if(other.collider.tag == "water")
		{
			Application.LoadLevel("GameOverMenuScene");
			Destroy(this);
		}

		if(other.collider.tag == "creepballoon")
		{
			Debug.Log("creep balloon reached");
			other.gameObject.transform.parent.SendMessage("BalloonHitt", SendMessageOptions.DontRequireReceiver);
			Debug.Log (other.contacts[0].point);
			Debug.Log (other.gameObject.transform.position);

			if(other.contacts[0].point.x >= other.gameObject.transform.position.x)
			{
				Debug.Log("right");
				this.transform.rigidbody2D.AddForceAtPosition(new Vector2(recoilvectorX,0),other.contacts[0].point);
			}
			else if(other.contacts[0].point.x <= other.gameObject.transform.position.x)
			{
				Debug.Log ("left");
				this.transform.rigidbody2D.AddForceAtPosition(new Vector2(-recoilvectorX,0),other.contacts[0].point);
			}

		}

		if(other.collider.tag == "creepbody")
		{
			Debug.Log("creep body reached");
			other.gameObject.SendMessage("BodyHit",  SendMessageOptions.DontRequireReceiver);
		}
		if(other.collider.tag == "obstacle" || other.collider.tag == "ground")
		{
			Debug.Log("player grounded");
			this.grounded = true;
		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		if(other.collider.tag == "obstacle" || other.collider.tag == "ground")
		{
			Debug.Log("player take off");
			this.grounded = false;
		}

	}
}
