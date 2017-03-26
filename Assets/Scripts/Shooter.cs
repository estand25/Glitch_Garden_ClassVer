using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject projectile,gun;

	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	void Start(){
		projectileParent = GameObject.Find ("Projectiles");

		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
		animator = GetComponent<Animator> ();
		setMyLaneSpawner ();
	}

	void Update(){
		if (isAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	private void FireGun(){
		GameObject newProjectile = Instantiate (projectile)as GameObject;
		newProjectile.transform.SetParent (projectileParent.transform);
		newProjectile.transform.position = gun.transform.position;
	}

	bool isAttackerAheadInLane(){
		//Exit if no attack in lane
		if(myLaneSpawner.transform.childCount <= 0){
			return false;
		}
	
		//If there are attackers, are they ahead
		foreach (Transform attacker in myLaneSpawner.transform) {
			if(attacker.transform.position.x > transform.position.x){
				return true;
			}
		}

		return false;
	}

	void setMyLaneSpawner(){
		Spawner[] allSpawner = GameObject.FindObjectsOfType<Spawner> ();

		foreach (Spawner thisSpawner in allSpawner) {
			if(thisSpawner.transform.position.y == transform.position.y)
			{
				myLaneSpawner = thisSpawner;
				return;
			}
		}

		Debug.LogError("You got nothing");
	}
}
