using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int breakableCount = 0;


	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");

		if (isBreakable) {
			breakableCount++;
			print (breakableCount);
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (isBreakable) {
			HandleHits ();
		}
		
	}

	void SimulateWin(){
		levelManager.LoadNextLevel ();
	}

	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];	
		}
	}

	void HandleHits(){
		timesHit++;
		//SimulateWin ();
		int maxHits = hitSprites.Length + 1;

		if (timesHit == maxHits) {
			breakableCount--;
			print (breakableCount);
			Destroy (gameObject);
			levelManager.BrickDestroyed ();
		} else {
			LoadSprites ();
		}
		
	}
}
