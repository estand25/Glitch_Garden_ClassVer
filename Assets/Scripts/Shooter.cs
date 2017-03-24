﻿using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject projectile,gun;
	private GameObject projectileParent;

	void Start(){
		projectileParent = GameObject.Find ("Projectiles");

		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
	}

	private void FireGun(){
		GameObject newProjectile = Instantiate (projectile)as GameObject;
		newProjectile.transform.SetParent (projectileParent.transform);
		newProjectile.transform.position = gun.transform.position;
	}
}
