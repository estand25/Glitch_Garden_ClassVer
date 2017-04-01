using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
	public float levelTime = 100;
 
	private Slider timerSlider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;

	// Use this for initialization
	void Start () {
		timerSlider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		levelManager = FindObjectOfType<LevelManager> ();
		FindYouWin ();
	}

	void FindYouWin(){
		winLabel = GameObject.Find ("You Won");
		if (!winLabel) {
			Debug.LogWarning("Please create you won");
		}
		
		winLabel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		timerSlider.value = Time.timeSinceLevelLoad / levelTime;

		if (Time.timeSinceLevelLoad >= levelTime && !isEndOfLevel) {
			audioSource.Play();
			winLabel.SetActive (true);
			Invoke("LoadNextLevel",audioSource.clip.length);
			isEndOfLevel = true;
		}
	}

	void LoadNextLevel(){
		levelManager.LoadNextLevel ();
	}

}
