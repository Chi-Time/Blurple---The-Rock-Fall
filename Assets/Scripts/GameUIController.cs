using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUIController : MonoBehaviour {
	
	private GameController gameControlRef;
	private Text timerDisplay;
	
	//Constructor
	void Awake ()
	{
		gameControlRef = GetComponentInParent<GameController>();
		timerDisplay = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		timerDisplay.text = "Current Time Lasted: " + 
				gameControlRef.hoursPlayerHasLasted.ToString("#00:") + 
				gameControlRef.minutesPlayerHasLasted.ToString("#00:") +
				gameControlRef.secondsPlayerHasLasted.ToString("#00");
	}
}
