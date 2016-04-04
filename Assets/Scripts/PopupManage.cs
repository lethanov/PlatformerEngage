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

	private bool _drag;
	private Collider2D _colliderComp;
	private Vector2 _lastSafePosition;
	private Vector2 _offset;
	private int _indexPatrol = 0;

	void Start(){
		_colliderComp = GetComponent<Collider2D>();

		if(IsCollidable){
			_colliderComp.isTrigger = false;
			if(CheckIfPlayerIsInside()){
				DestroyPopup();
			}
		} else {
			_colliderComp.isTrigger = true;
		}


	}

	// Update is called once per frame
	void Update () {
		if(_drag){
			Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = new Vector3(mouseWorldPosition.x + _offset.x, mouseWorldPosition.y + _offset.y, 0);
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
	}
}
