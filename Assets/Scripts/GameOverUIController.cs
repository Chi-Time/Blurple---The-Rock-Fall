using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverUIController : MonoBehaviour {
	
	private GameController gameControlRef;
	private GameObject gameOverPanel;
	public Text[] highScoreFields;
	
	//Constructor
	void Awake ()
	{
		gameControlRef = GetComponentInParent<GameController>();
		gameOverPanel = GameObject.Find("Game Over");
		gameOverPanel.SetActive(false);
	}

	void Update ()
	{
//		highScoreFields[0].text = "Score 1: " + PlayerPrefs.GetFloat("Score 1").ToString();
//		highScoreFields[1].text = "Score 2: " + PlayerPrefs.GetFloat("Score 2").ToString();
//		highScoreFields[2].text = "Score 3: " + PlayerPrefs.GetFloat("Score 3").ToString();
//		highScoreFields[3].text = "Score 4: " + PlayerPrefs.GetFloat("Score 4").ToString();
//		highScoreFields[4].text = "Score 5: " + PlayerPrefs.GetFloat("Score 5").ToString();
	}

	public void DisplayGameOver ()
	{
		gameOverPanel.SetActive(true);
		highScoreFields[5].text = "Your Score! " + gameControlRef.SetFinalScore().ToString("#0.00");
	}
}
