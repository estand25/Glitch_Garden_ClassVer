using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
	private Slider timerSlider;
	public int levelTime;

	// Use this for initialization
	void Start () {
		timerSlider = GameObject.FindObjectOfType<Slider> ();
		timerSlider.value = levelTime;
	}
	
	// Update is called once per frame
	void Update () {
		timerSlider.value = timerSlider.value - 1;
	}
}
