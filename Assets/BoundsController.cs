using UnityEngine;
using System.Collections;

public class BoundsController : MonoBehaviour {

	public GameObject boundsplane;
	GameObject xmax,ymax,xmin,ymin;
	public Camera camera;
	Vector2 bottomLeft;
	Vector2 topRight;
	Rect cameraRect;
	int rotationval;


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

		Debug.Log("ymax :"+cameraRect.yMax+" xmin :"+cameraRect.xMin+" ymin :"+cameraRect.yMin+" xmax :"+cameraRect.xMax);

		//instantiate planes
		//top side bound plane
		ymax = Instantiate(boundsplane, new Vector2 (0, cameraRect.yMax),Quaternion.identity) as GameObject;
		//bottom side bound plane
		ymin = Instantiate(boundsplane, new Vector2 (0, cameraRect.yMin),Quaternion.identity) as GameObject;

		/*
		//right side bound plane
		xmax = Instantiate(boundsplane, new Vector2 (cameraRect.xMax, (cameraRect.yMax + cameraRect.yMin)/2),Quaternion.identity) as GameObject;
		xmax.transform.Rotate(0,0,90);

		//left side bound plane
		xmin = Instantiate(boundsplane, new Vector2 (cameraRect.xMin, (cameraRect.yMax + cameraRect.yMin)/2),Quaternion.identity) as GameObject;
		xmin.transform.Rotate(0,0,90);
		*/

	}
	
	// Update is called once per frame
	void Update () {

	}
}
