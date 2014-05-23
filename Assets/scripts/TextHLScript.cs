using UnityEngine;
using System.Collections;

public class TextHLScript : MonoBehaviour {

	public GameObject ball, gameController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter(){
		this.renderer.material.color = new Color(0.5f,1f,0.5f);

	}

	void OnMouseExit(){
		this.renderer.material.color = new Color(0.5f,0.5f,0.5f);
		
	}

	void OnMouseOver(){
		if (Input.GetMouseButton(0)){
			Instantiate(ball, new Vector3(0,0,0), Quaternion.identity);
			renderer.enabled = false;
			collider.enabled = false;

			gameController.GetComponent<GameControl>().startGame = true;
			gameController.GetComponent<PaddleControl>().setupPhase = false;
			gameController.GetComponent<PaddleControl>().stealthPaddle.renderer.enabled = false;

		}
	}
}
