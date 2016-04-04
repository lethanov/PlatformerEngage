using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform TopLeftLimit;
	public Transform BottomRightLimit;
	public float speed;
	public Transform player;

	void Update () {
		float x = player.position.x;
		float y = player.position.y;

		if(x > BottomRightLimit.position.x){
			x = BottomRightLimit.position.x;
		}
		if(x < TopLeftLimit.position.x){
			x = TopLeftLimit.position.x;
		}

		if(y < BottomRightLimit.position.y){
			y = BottomRightLimit.position.y;
		}
		if(y > TopLeftLimit.position.y){
			y = TopLeftLimit.position.y;
		}

		Vector3 newPosition = new Vector3(x, y, transform.position.z);

		transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
	}
}
