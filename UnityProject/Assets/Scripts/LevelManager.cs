using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private int currentLevel;
	private static int breakableCount=0;
	public static bool autoPlay=false;
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			LoadLevel ("Start");
		}
		
		Debug.Log ("autoPlay: "+autoPlay);
	}		
							
	public void AutoPlayOn() {
		autoPlay=true;
	}
	
	public void AutoPlayOff() {
		autoPlay=false;
	}

	public void QuitRequest() {
		Application.Quit();
	}
	
	public static int GetBreakableCount() {
		return breakableCount;
	}
	
	public static void IncrementBreakableCount() {
		breakableCount++;		
	}
	
	public static void DecrementBreakableCount() {
		breakableCount--;		
	}
	
	public void LoadLevel(string name) {
		Application.LoadLevel(name);
	} 

	public void LoadNextLevel() {
		breakableCount=0;
		Application.LoadLevel (Application.loadedLevel + 1);
		if (Application.loadedLevelName=="Lose" || 
			Application.loadedLevelName=="Win" ||
			Application.loadedLevelName=="Start") {
				AutoPlayOff();
			}
	}

	public void BrickDestroyed() {
		if (GetBreakableCount()<=0) {
			LoadNextLevel ();
		}
	}

}
