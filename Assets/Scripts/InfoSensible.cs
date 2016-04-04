using UnityEngine;
using System.Collections;

public class InfoSensible : MonoBehaviour {

	public Transform[] Checkpoints;

	private int currentCheckpoint;
	private float timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(currentCheckpoint < Checkpoints.Length){
			transform.position = Vector3.Lerp(transform.position, Checkpoints[currentCheckpoint].position, Time.deltaTime * 2);
		}		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "Player"){
			if(timer > 1.0f){
				currentCheckpoint ++;
			}
		}
	}
}
