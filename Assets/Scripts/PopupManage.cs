using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class PopupManage : MonoBehaviour {

	public LayerMask playerMask;
	public bool isDraggable;
	public bool isCollidable;

	private bool drag;
	private Collider2D _colliderComp;
	private Vector2 _lastSafePosition;
	public Vector2 _offset;

	void Start(){
		_colliderComp = GetComponent<Collider2D>();

		if(isCollidable){
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
		if(drag){
			Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = new Vector3(mouseWorldPosition.x + _offset.x, mouseWorldPosition.y + _offset.y, 0);
		}
	}
		
	bool CheckIfPlayerIsInside(){
		Collider2D test = Physics2D.OverlapArea(_colliderComp.bounds.min, _colliderComp.bounds.max, playerMask);

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
		if(isDraggable){
			drag = true;
			_colliderComp.isTrigger = true;
			_lastSafePosition = transform.position;
			_offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}

	void OnMouseUp(){
		if(isDraggable){
			drag = false;
			if(isCollidable && CheckIfPlayerIsInside()){
				transform.position = _lastSafePosition;
			} else {
				_lastSafePosition = transform.position;
			}
			_colliderComp.isTrigger = false;
		}
	}

	public void DestroyPopup(){
		Destroy(gameObject);
	}


}
