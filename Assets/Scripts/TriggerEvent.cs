using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class TriggerEvent : MonoBehaviour {

	[Header("False : Mouse Click, True : Player Touches")]
	public bool Mode;

	[Header("TRIGGER ON MOUSE CLICK")]
	public UnityEvent OnTriggerMouseClick;
	[Header("TRIGGER ON PLAYER TOUCHES")]
	public UnityEvent OnTriggerPlayerTouch;

	void Start(){
		Destroy(GetComponent<SpriteRenderer>());
	}

	void OnMouseDown(){
		if(!Mode){
			if(OnTriggerMouseClick != null){
				OnTriggerMouseClick.Invoke();
				DestroySelf();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(Mode){
			if(other.name == "Player"){
				if(OnTriggerPlayerTouch != null){
					OnTriggerPlayerTouch.Invoke();
					DestroySelf();
				}
			}
		}
	}

	public void DestroySelf(){
		Destroy(gameObject);
	}
}
