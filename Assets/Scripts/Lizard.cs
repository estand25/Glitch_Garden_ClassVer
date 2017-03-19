using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard: MonoBehaviour {
	private Animator animator;
	private Attacker attacker; 

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		attacker = GetComponent<Attacker> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter2D(Collider2D col){
		GameObject obj = col.gameObject;

		if (!obj.GetComponent<Defenders> ()) {
			return;
		}
		animator.SetBool("isAttacking",true);
		attacker.Attack (obj);
		attacker.StrikeCurrentTarget (5f);
	}
}
