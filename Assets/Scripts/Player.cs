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

	private float _initScale;
	private Vector3 _startPosition;
	private Transform _checkpoint;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		_initScale = transform.FindChild("Gfx").localScale.x;
		_startPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {
		OnGround();
		HandleAnimation();

		xVel = Input.GetAxis("Horizontal") * speed;

		if(xVel > 0){
			transform.FindChild("Gfx").localScale = new Vector2(_initScale, _initScale);
		} 
		if(xVel < 0){
			transform.FindChild("Gfx").localScale = new Vector2(-_initScale, _initScale);
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
			_nexAnim = "Jump";
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
		Collider2D hit = Physics2D.OverlapArea(transform.FindChild("A").position, transform.FindChild("B").position, collisionMask);
		if(hit != null && hit.isTrigger == false){
			try {
				hit.gameObject.GetComponent<PopupManage>().IsDraggable = false;
			} catch {
				bool da = true;
			}
			onGround = true;
		} else {
			onGround = false;
		}
	}

	public void SetNewCheckpoint(Transform _newCheckpoint){
		_checkpoint = _newCheckpoint;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.layer == 10){
			Respawn();
		}
	}

	void Respawn(){
		if(_checkpoint == null){
			transform.position = _startPosition;
		} else {
			transform.position = _checkpoint.position;
		}
	}
}
