using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {
	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		if (musicManager) {
			musicManager.ChangeVolume (PlayerPrefsManager.GetMasterVolumne ());
		} else {
			Debug.LogWarning("Cannot found musicManager so cannot update scene sound");
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
