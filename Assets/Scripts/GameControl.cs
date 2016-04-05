using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	private float _timer;

	void Start () {
		_timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		_timer += Time.deltaTime;
		if(_timer > 60){
			int count = Random.Range(0, 5);

			int index = 0;
			while(index < count){
				Vector3 randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Camera.main.pixelWidth), Random.Range(0, Camera.main.pixelWidth), 0));
				randomPosition = new Vector3(randomPosition.x, randomPosition.y, 0);
				Instantiate(Resources.Load("PopupError" + Random.Range(1, 9).ToString()), randomPosition, Quaternion.identity);					
				index ++;
			}

			_timer = 0;
		}
	}
}
