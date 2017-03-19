using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col){
		if (col) {
			Debug.Log(this.name+" is getting Hit by "+col);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.collider) {
			Debug.Log(this.name+" is hitting something "+coll);
		}
	}
}
