using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType <Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse ();	
		} else {
			AutoPlay ();
		}
	}

	void  MoveWithMouse(){
		Vector3 paddlePosition = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePositionInBlocks = Input.mousePosition.x / Screen.width * 14;
		//print (mousePositionInBlocks);

		paddlePosition.x = Mathf.Clamp(mousePositionInBlocks, 0.5f, 13.7f);

		this.transform.position = paddlePosition;
	}

	void AutoPlay(){
		Vector3 paddlePosition = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPosition = ball.transform.position;
		//print (mousePositionInBlocks);

		paddlePosition.x = Mathf.Clamp(ballPosition.x, 0.5f, 13.7f);

		this.transform.position = paddlePosition;

	}
}
