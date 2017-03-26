using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject[] attackersPrefabArray;
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackersPrefabArray){
			if (isTimeToSpawn (thisAttacker)) {
				Spawn(thisAttacker);
			}			
		}
	}

	bool isTimeToSpawn(GameObject myAttackerGameObject)
	{
		Attacker attacker = myAttackerGameObject.GetComponent<Attacker> ();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning("Spawn rate capped by frame rate");
		}

		float threshold = spawnsPerSecond * Time.deltaTime/5;

		if (Random.value < threshold) {
			return true;
		} else {
			return false;
		}
	}

	void Spawn(GameObject myGameObject)
	{
		GameObject myAttacker = Instantiate (myGameObject, transform.position, Quaternion.identity) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
}
