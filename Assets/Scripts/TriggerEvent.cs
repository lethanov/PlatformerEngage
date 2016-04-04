using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class TriggerEvent : MonoBehaviour {

	public UnityEvent OnTrigger;

	void Start(){
		Destroy(GetComponent<SpriteRenderer>());
	}

	void OnMouseDown(){
		if(OnTrigger != null){
			OnTrigger.Invoke();
		}
	}
}
