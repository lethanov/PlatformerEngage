using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float speed;
	public Transform player;

	void Update () {

		Vector3 newPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);

		transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
	}
}
