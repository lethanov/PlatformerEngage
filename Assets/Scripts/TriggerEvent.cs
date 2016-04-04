using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class TriggerEvent : MonoBehaviour {

	[Header("TRIGGER ON MOUSE CLICK")]
	public UnityEvent OnTriggerMouseClick;
	[Header("TRIGGER ON PLAYER TOUCHES")]
	public UnityEvent OnTriggerPlayerTouch;

	void Start(){
		//Destroy(GetComponent<SpriteRenderer>());
	}

	void OnMouseDown(){
		if(OnTriggerMouseClick != null){
			OnTriggerMouseClick.Invoke();
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.name == "Player"){
			if(OnTriggerPlayerTouch != null){
				OnTriggerPlayerTouch.Invoke();
				Destroy(gameObject);
			}
		}
	}

	public void DestroySelf(){
		Destroy(gameObject);
	}
}
