using UnityEngine;
using System.Collections;

public class PaddleControl : MonoBehaviour {

	public bool paddleSet = false;
	public bool setupPhase = true;
	private float ticker = 0.2f;
	public Camera mainCamera;
	public GameObject newPaddle, enemyPaddle, stealthPaddle, stealthPaddlePreFab;
	public bool runOnce = false;
	private Vector3 myPos;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		ticker -= Time.deltaTime;
		if (setupPhase) {
			if (runOnce){
				stealthPaddle.renderer.enabled = true;
				runOnce = false;
				Debug.Log("Boop!");
			}

			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 0f;
			mousePos.y -= Screen.height/2;
			myPos = transform.position;

			float limiter = Screen.height * 0.1f;
			myPos.y = mousePos.y/limiter;
			if (myPos.y > 3.5f) {myPos.y = 3.5f;} 
			if (myPos.y < -3.5f) {myPos.y = -3.5f;}
			transform.position = myPos;

			stealthPaddle.transform.position = new Vector3(-8.3f, myPos.y, 0);

			if (Input.GetMouseButton(0) && ticker < 0) {

				this.GetComponent<GameControl>().paddleCounter++;

				GameObject neuPad = Instantiate(newPaddle, new Vector3(-8.3f, myPos.y, 0), Quaternion.identity) as GameObject;

				neuPad.GetComponent<PaddleData>().paddleCounter = this.GetComponent<GameControl>().paddleCounter;
				ticker = 0.2f;

				Color ahaa = neuPad.renderer.material.color;
				ahaa.a -= 0.1f*this.GetComponent<GameControl>().paddleCounter;
				neuPad.renderer.material.color = ahaa;


				this.GetComponent<GameControl>().paddleCounter++;

				GameObject neuPadE = Instantiate(enemyPaddle, new Vector3(8.3f, Random.Range (-3.5f, 3.5f), 0), Quaternion.identity) as GameObject;

				neuPadE.GetComponent<PaddleData>().paddleCounter = this.GetComponent<GameControl>().paddleCounter;

				Color ahaae = neuPadE.renderer.material.color;
				ahaae.a -= 0.1f*this.GetComponent<GameControl>().paddleCounter;
				neuPadE.renderer.material.color = ahaae;
			}
		}
	}
}
