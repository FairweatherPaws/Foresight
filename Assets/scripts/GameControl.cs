using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public float playerScore = 0;
	public float enemyScore = 0;
	public bool scored = false;
	public bool scoreAdded = false;
	public GameObject pScore, eScore;
	public int paddleCounter = 0;
	public int bounces = 0;
	public int lister = 0;
	public bool bounced = false;
	public bool startGame = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (startGame) {
			lister = 0;
			foreach(GameObject lezPlay in GameObject.FindGameObjectsWithTag("Paddle")) {
				lister++;
				if (lezPlay.GetComponent<PaddleData>().paddleCounter <= bounces + 2) {
					lezPlay.collider.enabled = true;
				}
			}
		}
		if (scored) {
			if (scoreAdded) {
				pScore.GetComponent<TextMesh>().text = playerScore.ToString();
				eScore.GetComponent<TextMesh>().text = enemyScore.ToString();
				scoreAdded = false;
			}
			foreach(GameObject shitstain in GameObject.FindGameObjectsWithTag("Paddle")) {
				Destroy(shitstain.gameObject);
			}
			this.GetComponent<PaddleControl>().runOnce = true;
			this.GetComponent<PaddleControl>().setupPhase = true;
			paddleCounter = 0;
			bounces = 0;
			scored = false;
		}
		if (bounced) {
			foreach(GameObject lezPlay in GameObject.FindGameObjectsWithTag("Paddle")) {
				if (lezPlay.GetComponent<PaddleData>().paddleCounter <= bounces + 2) {
					lezPlay.collider.enabled = true;
				}
				if (lezPlay.GetComponent<PaddleData>().paddleCounter <= bounces){
					Destroy (lezPlay.gameObject);
				}
				else {
					Color weeb = lezPlay.renderer.material.color;
					weeb.a += 0.1f;
					lezPlay.renderer.material.color = weeb;
				}
			}
			bounced = false;
		}
	}
}
