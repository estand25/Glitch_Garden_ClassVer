using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {
	private Text starsText;
	private int stars = 100;
	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		starsText = GetComponent<Text> ();
		UpdateDisplay ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddStars(int amount){
		stars += amount;
		UpdateDisplay ();
	}

	public Status UseStar(int amount){
		if (stars >= amount) {
			stars -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		} 
		return Status.FAILURE;
	}

	private void UpdateDisplay(){
		starsText.text = stars.ToString ();
	}
}
