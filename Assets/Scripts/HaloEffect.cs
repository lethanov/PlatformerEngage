using UnityEngine;
using System.Collections;

public class HaloEffect : MonoBehaviour {

	private float alpha;
	private float scale;

	// Use this for initialization
	void Start () {
		alpha = 1.0f;
		scale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(alpha > 0){
			alpha -= 0.01f;
			scale += 0.05f;
		} else {
			Destroy(gameObject);
		}
		transform.localScale = new Vector3(scale, scale, scale);
		GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
	}
}
