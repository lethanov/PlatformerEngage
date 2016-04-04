using UnityEngine;
using System.Collections;

public class ScaleEffect : MonoBehaviour {

	private bool effect;
	private float scaleFactor;

	private float scale;
	// Use this for initialization
	void Start () {
		scale = transform.localScale.x;
		scaleFactor = Random.Range(0, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
