using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class InfoSensible : MonoBehaviour {

	public Transform[] Checkpoints;

	private int currentCheckpoint;
	private float timer;

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
				if(currentCheckpoint < Checkpoints.Length) GameObject.Find("Player").GetComponent<Player>().SetNewCheckpoint(Checkpoints[currentCheckpoint]);
				currentCheckpoint ++;
			}
		}
	}
}
