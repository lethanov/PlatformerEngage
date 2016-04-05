using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class PopupManage : MonoBehaviour {


	[Header("Must be set to Player Mask")]
	public LayerMask PlayerMask;

	[Header("Can it collide with player ?")]
	public bool IsCollidable;

	[Header("Can it be dragged by mouse ?")]
	public bool IsDraggable;

	[Header("Does it popup instant ?")]
	public bool InstantInit;

	[Header("---IF NOT DRAGGABLE---")]
	[Header("Go back to init position When reaching his destination ?")]
	public bool IsHoming;

	[Header("Destination where object must go")]
	public Transform DestinationTarget;

	[Header("Movement speed")]
	public float MovementSpeed;

	[Header("How many times object patrol from origin to destination ? (If Homing)")]
	public int CountPatrol; 

	[Header("Apply Random movement ? (If NOT Homing)")]
	public bool RandomMovement;

	[Header("Step for each random movement")]
	public float RandomStep;

	private bool _drag;
	private Collider2D _colliderComp;
	private Vector2 _lastSafePosition;
	private Vector2 _offset;
	private int _indexPatrol = 0;
	private bool _triggered = false;
	private bool _backToHome = false;
	private float _timeRandom = 0;
	private Vector3 destinationRandom;
	private float _normalScale;
	private float _scale;

	private Vector3 _origin;

	void Start(){
		_colliderComp = GetComponent<Collider2D>();
		_origin = transform.position;

		_scale = 1;
		_normalScale = transform.localScale.x;
		transform.localScale = new Vector3(_scale, _scale, _scale);

		if(IsCollidable){
			_colliderComp.isTrigger = false;
			if(CheckIfPlayerIsInside()){
				DestroyPopup();
			}
		} else {
			_colliderComp.isTrigger = true;
		}

		if(!IsDraggable){
			GetComponent<SpriteRenderer>().enabled = false;
			_colliderComp.isTrigger = true;
		}

		destinationRandom = transform.position;

		if(InstantInit){
			GetComponent<SpriteRenderer>().enabled = true;
			_triggered = true;
		}
	}

	// Update is called once per frame
	void Update () {
		_timeRandom += Time.deltaTime;
		if(_drag){
			Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = new Vector3(mouseWorldPosition.x + _offset.x, mouseWorldPosition.y + _offset.y, 0);
		}
		if(_triggered){
			transform.localScale = new Vector3(_scale, _scale, _scale);
			if(_scale < _normalScale){
				_scale += 0.1f;
			} else {
				_scale = _normalScale;
			}
			if(IsHoming){
				if(CountPatrol > 0 && _indexPatrol < CountPatrol){
					Move();
				}
				if(CountPatrol == -1){
					Move();
				} else {
					if(_indexPatrol >= CountPatrol){
						Destroy(gameObject);
					}
				}
			} else {
				if(RandomMovement){
					if(_timeRandom > RandomStep){
						
						//destinationRandom = new Vector3(transform.position.x + Random.Range(-5.0f, 5.0f), transform.position.y + Random.Range(-5.0f, 5.0f), 0);
						destinationRandom = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Camera.main.pixelWidth), Random.Range(0, Camera.main.pixelWidth), 0));
						destinationRandom = new Vector3(destinationRandom.x, destinationRandom.y, 0);
						_timeRandom = 0;
					}
					transform.position = Vector3.Lerp(transform.position, destinationRandom, Time.deltaTime * MovementSpeed);
				}
			}
		}
	}

	void Move(){
		if(!RandomMovement){
			float step = MovementSpeed * Time.deltaTime;
			if(!_backToHome){
				transform.position = Vector3.MoveTowards(transform.position, DestinationTarget.position, step);
				if(transform.position == DestinationTarget.position){
					_backToHome = true;
					_indexPatrol ++;
				}
			}
			if(_backToHome){
				transform.position = Vector3.MoveTowards(transform.position, _origin, step);
				if(transform.position == _origin){
					_backToHome = false;
					_indexPatrol ++;
				}
			}
		}
	}

	bool CheckIfPlayerIsInside(){
		Collider2D test = Physics2D.OverlapArea(_colliderComp.bounds.min, _colliderComp.bounds.max, PlayerMask);

		if(test != null){
			if(test.tag == "Player"){
				return true;
			} else {
				return false;
			}
		} else {
			return false;
		}
	}

	void OnMouseDown(){
		if(IsDraggable){
			_drag = true;
			_colliderComp.isTrigger = true;
			_lastSafePosition = transform.position;
			_offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}

	void OnMouseUp(){
		if(IsDraggable){
			_drag = false;
			if(IsCollidable && CheckIfPlayerIsInside()){
				transform.position = _lastSafePosition;
			} else {
				_lastSafePosition = transform.position;
			}
			if(IsCollidable){
				_colliderComp.isTrigger = false;
			}
		}
	}

	public void DestroyPopup(){
		Destroy(gameObject);
	}

	public void Trigger(){
		_triggered = true;
		GetComponent<SpriteRenderer>().enabled = true;
		if(IsCollidable){
			_colliderComp.isTrigger = false;
		}
	}
}
