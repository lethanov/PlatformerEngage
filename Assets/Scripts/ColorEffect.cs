using UnityEngine;
using System.Collections;

public class ColorEffect : MonoBehaviour {

	public float scale = 50f;

	// Use this for initialization
	void Start () {
		float red = 0f;
		float blue = 0f;


		float distance = Vector2.Distance(transform.position, new Vector2(0f, 0f));

		red = distance / scale;
		blue = 1 - distance / scale;

		transform.GetComponent<SpriteRenderer>().color = new Color(red, 0f, blue);
	}
}
