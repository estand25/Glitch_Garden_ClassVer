using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Defenders))]
public class Projectiles : MonoBehaviour {
	public float Speed;
	public float Damage;

	private Animator animator;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Speed * Time.deltaTime);
	}

	
	void OnTriggerEnter2D(Collider2D col){
		GameObject obj = col.gameObject;
		
		if (!obj.GetComponent<Attacker> ()) {
			return;
		}
		if (obj.GetComponent<Attacker> ()) {
			Health health = obj.GetComponent<Health>();
			if(health){
				health.DealDamage(Damage);
				Destroy(gameObject);
			}
		}
	}
}
