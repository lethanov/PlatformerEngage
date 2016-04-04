using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public LayerMask collisionMask;

	private float xVel;
	private float yVel;

	private Rigidbody2D rb;
	private bool onGround;

	private string _nexAnim = "Idle";
	private string _curAnim = "";

	private float initScale;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		initScale = transform.FindChild("Gfx").localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		OnGround();
		HandleAnimation();

		xVel = Input.GetAxis("Horizontal") * speed;

		if(xVel > 0){
			transform.FindChild("Gfx").localScale = new Vector2(initScale, initScale);
		} 
		if(xVel < 0){
			transform.FindChild("Gfx").localScale = new Vector2(-initScale, initScale);
		}

		if(onGround){
			if(Input.GetButton("Jump")){
				yVel = 20;
				_nexAnim = "Jump";
			} else {
				yVel = 0;
				_nexAnim = "Idle";
				if(xVel != 0){
					_nexAnim = "Run";
				}
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

	void HandleAnimation(){
		if(_curAnim  != _nexAnim){
			_curAnim = _nexAnim;
			transform.FindChild("Gfx").GetComponent<Animator>().Play(_curAnim);
		}
	}

	void OnGround() {
		if(Physics2D.OverlapArea(transform.FindChild("A").position, transform.FindChild("B").position, collisionMask)){
			onGround = true;
		} else {
			onGround = false;
		}
	}
}
