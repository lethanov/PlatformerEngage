using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	private float alpha;

	// Use this for initialization
	void Start () {
		alpha = 0.0f;
		GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
	}

	// Update is called once per frame
	void Update () {
		if(alpha < 1){
			alpha += 0.01f;
		}
		GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
	}
}
