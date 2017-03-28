using UnityEngine;
using System.Collections;

public class DefenderSpawer : MonoBehaviour {
	public Camera myCamera;
	private GameObject parent;
	private StarDisplay starDispaly;

	void Start(){
		parent = GameObject.Find ("Defenders");
		starDispaly = GameObject.FindObjectOfType<StarDisplay> ();

		if (!parent) {
			parent = new GameObject("Defenders");
		}
	}

	void OnMouseDown(){
		Vector2 rawPos = CalculateWorldPointOfMouseClick ();
		Vector2 roundedPos = SnapToGrid (rawPos);
		GameObject defender = Button.selectedDefender;
		Defenders defOjb = defender.GetComponent<Defenders> ();

		if (StarDisplay.Status.SUCCESS == starDispaly.UseStar (defOjb.starCost)) {
			SpawnDefender (roundedPos, defender);
		}
		else {
			Debug.Log ("Insufficient stars");
		}
	}

	void SpawnDefender (Vector2 roundedPos,GameObject defender)
	{
		Quaternion zeroRot = Quaternion.identity;
		GameObject newDef = Instantiate (defender, roundedPos, zeroRot) as GameObject;
		newDef.transform.parent = parent.transform;

	}

	Vector2 SnapToGrid(Vector2 rawWorldPos){
		float newX = Mathf.RoundToInt (rawWorldPos.x);
		float newY = Mathf.RoundToInt (rawWorldPos.y);
		return new Vector2 (newX, newY);
	}

	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);

		return worldPos;
	}
}
