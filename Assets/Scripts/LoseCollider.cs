using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelmanager;

	void Start(){
		levelmanager = FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		GameObject obj = col.gameObject;
		
		if (!obj.GetComponent<Attacker> ()) {
			return;
		} else {
			Destroy(obj);
			levelmanager.LoadLevel("03b.Lose");
		}
	}
}
