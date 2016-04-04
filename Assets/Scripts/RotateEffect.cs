using UnityEngine;
using System.Collections;

public class RotateEffect : MonoBehaviour {

	private float angle;

	// Use this for initialization
	void Start () {
		angle = Random.Range(-0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, angle);
	}
}
