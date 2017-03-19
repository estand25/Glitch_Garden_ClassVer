using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {
	private Health health;
	private float myHealth;

	// Use this for initialization
	void Start () {
		myHealth = GetComponent<Health> ().health();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D col){
		GameObject obj = col.gameObject;
		if (obj) {
			Debug.Log(name+" triggered by "+obj);
		}
	}
}