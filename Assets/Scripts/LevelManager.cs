using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start(){
		if (autoLoadNextLevelAfter <= 0) {
			Debug.Log ("Level auto load disabled, use a positive number in seconds");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}
	// Load level for the name scence
	public void LoadLevel(string name){
		// Output the current load level
		Debug.Log("Level load requested for: "+name);
		
		// Load the level
		Application.LoadLevel(name);
	}
	
	// Quit the game
	public void QuitRequest(){
		// Output the quit message
		Debug.Log("I want quit!");
		
		// Quit the application
		Application.Quit();
	}
	
	//Load the next scence based on the build numbers
	public void LoadNextLevel(){
		//yield return new WaitForSeconds(fadeTime);

		// Load the next level based on the current load level plus 1
		Application.LoadLevel(Application.loadedLevel+1);
		//float fadeTime = GameObject.Find ("Panel").GetComponent<Fading> ().BeginFade (1);
	}

}
