using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour {

	public float xDir = -5f;
	public float yDir = 5f;
	private float cooldown = 0f;
	private float sideCool = 0f;

	// Use this for initialization
	void Start () {
		xDir = -5f;
		yDir = 5f;
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(xDir*Time.deltaTime, yDir*Time.deltaTime, 0);
		cooldown -= Time.deltaTime;
		sideCool -= Time.deltaTime;
	}

	void OnCollisionEnter (Collision collDetect) {

		GameObject gc = GameObject.FindGameObjectWithTag("GameController");
		GameControl Script1 = gc.GetComponent<GameControl>();

		GameObject rb = GameObject.FindGameObjectWithTag("ReadyButton");
		TextHLScript Script2 = rb.GetComponent<TextHLScript>();
		if (collDetect.gameObject.tag == "Side" && sideCool < 0) {
			yDir *= -1;

			sideCool = 0.05f;
		}
		if (collDetect.gameObject.tag == "Paddle" && cooldown < 0) {
			xDir *= -1;

			Script1.bounces++;
			Script1.bounced = true;
			cooldown = 0.05f;
			xDir *= 1.1f;
			yDir *= 1.1f;
		}
		if (collDetect.gameObject.tag == "LGoal") {

			Script1.enemyScore++;
			Script1.scored = true;
			Script1.scoreAdded = true;

			Script2.renderer.enabled = true;
			Script2.collider.enabled = true;
			Destroy(this.gameObject);

		}
		if (collDetect.gameObject.tag == "RGoal") {
			Script1.playerScore++;
			Script1.scored = true;
			Script1.scoreAdded = true;


			Script2.renderer.enabled = true;
			Script2.collider.enabled = true;
			Destroy(this.gameObject);
		}
	}
}
