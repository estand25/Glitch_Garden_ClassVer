using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {
	[Range(-1f,1.5f)]
	private float currentSpeed;
	private GameObject currentTarget;
	private float myHealth;
	private Animator animator;

	// Use this for initialization
	void Start () {
		myHealth = GetComponent<Health> ().health();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if(!currentTarget)
			animator.SetBool("isAttacking",false);
	}

	public void setSpeed(float speed){
		currentSpeed = speed;
	}

	//Called from the called once per frame
	public void StrikeCurrentTarget(float damage){
		//if (currentTarget) {
		//Debug.Log ("Strike target " + currentTarget.name);
		//currentTarget.GetComponent<Health> ().takingDamage (damage);
		//}
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if(health){
				health.DealDamage(damage);
			}
		}
	}

	public void Attack(GameObject obj){
		currentTarget = obj;
	}

}
