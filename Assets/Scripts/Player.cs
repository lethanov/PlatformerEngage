using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public LayerMask collisionMask;

	private float xVel;
	private float yVel;

	private Rigidbody2D rb;
	private bool onGround;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		OnGround();

		xVel = Input.GetAxis("Horizontal") * speed;

		if(onGround){
			if(Input.GetButton("Jump")){
				yVel = 20;
			} else {
				yVel = 0;
			}
		} else {
			if(yVel < -20){
				yVel = -20;
			} else {
				yVel = rb.velocity.y;
			}
		}
			
		rb.velocity = new Vector2(xVel, yVel);
	}

	void OnGround() {
		if(Physics2D.OverlapArea(transform.FindChild("A").position, transform.FindChild("B").position, collisionMask)){
			onGround = true;
		} else {
			onGround = false;
		}
	}
}
