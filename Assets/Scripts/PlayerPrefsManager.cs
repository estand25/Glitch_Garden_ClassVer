using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {
	const string MASTER_VOLUMNE_KEY = "master_volume";
	const string DIFFICULT_KEY = "difficult";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolumne(float volumne){
		if (volumne >= 0f && volumne <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUMNE_KEY, volumne);
		} else {
			Debug.LogError("Master volumn out of range");
		}
	}

	public static float GetMasterVolumne(){
		return PlayerPrefs.GetFloat (MASTER_VOLUMNE_KEY);
	}

	public static void UnlockLevel(int level){
		if (level <= Application.levelCount - 1) {
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); //use 1 for true
		} else {
			Debug.LogError("Trying to unlock not in build order");
		}
	}

	public static bool IsLevelUnlocked(int level){
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());
		bool isLevelUnlock = (levelValue == 1);

		if (level <= Application.levelCount - 1) {
			return isLevelUnlock; 
		}else {
			Debug.LogError("Trying to get information about a level not in build order");
		}
		return false;
	}

	public static void SetDifficulty(float difficulty){
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat(DIFFICULT_KEY,difficulty);
		} else {
			Debug.LogError("Trying to set difficult that doesn't exist");
		}
	}

	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULT_KEY);
	}
}
