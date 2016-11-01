using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Text tileCounter;
	public Text pfCounter;
	public Text maxDisplay;

	
	// Update is called once per frame
	void Update () {

		maxDisplay.text = " "+Pathmaker.trueMax;
		tileCounter.text = " "+Pathmaker.totalCounter;
		pfCounter.text = " "+Pathmaker.totalPM;

		//R resets and restarts the level
		if (Input.GetKeyDown (KeyCode.R)) {
			Pathmaker.trueMax = 0;
			Pathmaker.totalCounter = 0;
			Pathmaker.totalPM = 1;
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
