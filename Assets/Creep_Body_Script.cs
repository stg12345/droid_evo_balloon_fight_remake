using UnityEngine;
using System.Collections;

public class Creep_Body_Script : MonoBehaviour {

	bool grounded = true;
	bool parachute = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.collider.tag == "playerbody")
		{
			Debug.Log("player body reached");
		}

		if(other.collider.tag == "playerballoon")
		{
			Debug.Log("player balloon reached");
		}
	
		if((other.collider.tag == "obstacle" || other.collider.tag == "ground") && this.parachute == true)
		{
			Debug.Log("creep grounded");
			this.grounded = true;
		}

	}

	void BalloonHitt()
	{	Debug.Log("balloon hit :");
		if(this.parachute == false)
		{
			Debug.Log("parachute hit :"+this.parachute);

			this.parachute = true;
		}
		else if(this.parachute == true)
		{
			Debug.Log("creep dead");
		}
	}

	void BodyHit()
	{
		if(this.grounded == true)
		{
			Debug.Log ("creep killed on ground");
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if((other.collider.tag == "obstacle" || other.collider.tag == "ground"))
		{
			Debug.Log("creep take off");
			this.grounded = false;
			this.parachute = false;
		}
		
	}
}
