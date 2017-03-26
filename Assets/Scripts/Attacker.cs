using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {
	[Range(-1f,1.5f)]
	private float currentSpeed;

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
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
