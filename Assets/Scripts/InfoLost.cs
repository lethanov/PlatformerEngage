using UnityEngine;
using System.Collections;

public class InfoLost : MonoBehaviour {

	private Vector3 startPosition;
	private Vector3 finalPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		finalPosition = new Vector3(startPosition.x + Random.Range(-10, 10), startPosition.y + Random.Range(-10, 10), 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, finalPosition, Time.deltaTime * 0.5f);
	}
}
