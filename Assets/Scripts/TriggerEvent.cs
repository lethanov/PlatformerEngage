using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class TriggerEvent : MonoBehaviour {

	public UnityEvent OnTrigger;

	void OnMouseDown(){
		if(OnTrigger != null){
			OnTrigger.Invoke();
		}
	}
}
