using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;
	public GameObject smoke;


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
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
		
	}

	void SimulateWin(){
		levelManager.LoadNextLevel ();
	}

	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex] != null) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];	
		} else {
			Debug.LogError ("Falta un Brick sprite");
		}
	}

	void HandleHits(){
		timesHit++;
		//SimulateWin ();
		int maxHits = hitSprites.Length + 1;

		if (timesHit == maxHits) {
			breakableCount--;
			print (breakableCount);
			PuffSmoke ();
			Destroy (gameObject);
			levelManager.BrickDestroyed ();
		} else {
			LoadSprites ();
		}
		
	}

	void PuffSmoke(){
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem> ().startColor = gameObject.GetComponent<SpriteRenderer> ().color;
	}
}
