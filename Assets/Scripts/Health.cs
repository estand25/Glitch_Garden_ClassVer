using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float myHealth;

	public float health()
	{
		return myHealth;
	}

	public void DealDamage(float damage){
		myHealth -= damage;

		if (myHealth <= 0) {
			//Optionally trigger animation
			DestroyObject();
		}
	}

	public void DestroyObject(){
		Destroy (gameObject);
	}
}
