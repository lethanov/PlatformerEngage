using UnityEngine;
using System.Collections;

public class ScaleEffect : MonoBehaviour {

	private bool effect;
	private float scaleFactor;

	private float scale;
	private float delay;
	private float timer = 0;
	// Use this for initialization
	void Start () {
		delay = Random.Range(0.5f, 1f);
		effect = false;
		scale = transform.localScale.x;
		scaleFactor = Random.Range(0.001f, 0.005f);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(!effect){
			scale += scaleFactor;
			if(timer > delay){
				timer = 0;
				effect = true;
			}
		}
		if(effect){
			scale -= scaleFactor;
			if(timer > delay){
				timer = 0;
				effect = false;
			}
		}
		transform.localScale = new Vector3(scale, scale, scale);
	}
}
