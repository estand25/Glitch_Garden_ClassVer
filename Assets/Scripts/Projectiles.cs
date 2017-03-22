using UnityEngine;
using System.Collections;

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
}
