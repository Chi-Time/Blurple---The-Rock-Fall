using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	[Tooltip("The amount of times the player can be hit.")]
	public int playerHealth;
	[Tooltip("The amount of times the player can die before the game ends.")]
	public int playerLives;
	[HideInInspector]
	public float secondsPlayerHasLasted;		//The time in seconds of how the long the player has lived for.
	[HideInInspector]
	public float minutesPlayerHasLasted;			//The time in minutes of how the long the player has lived for.
	[HideInInspector]
	public float hoursPlayerHasLasted;			//The time in hours of how the long the player has lived for.
	[HideInInspector]
	public bool playerKilled;							//Whether or not the player has run out of lives.
	[HideInInspector]
	public bool invulnerable;							//Whether or not the player is invulnerable.
	public GameObject pausedScreenPanel;

	private int storedHealth;
	private GameOverUIController gameOverUI;


	void Awake ()
	{
		gameOverUI = GetComponentInChildren<GameOverUIController>();
		pausedScreenPanel.SetActive(false);
	}

	void Start ()
	{
		playerKilled = false;
		invulnerable = false;
		storedHealth = playerHealth;
	}

	void Update ()
	{
		if(!playerKilled)
		{
			secondsPlayerHasLasted += Time.deltaTime;
			if(secondsPlayerHasLasted >= 60)
			{
				minutesPlayerHasLasted++;
				secondsPlayerHasLasted = 0;
			}
			if(minutesPlayerHasLasted >= 60)
			{
				hoursPlayerHasLasted++;
				minutesPlayerHasLasted = 0;
			}
		}
		else {
			if(Input.GetButton("Restart"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			if(Input.GetKey(KeyCode.Return))
			{
				Application.Quit();
			}
//			if(Input.anyKeyDown)
//			{
//				Application.LoadLevel(Application.loadedLevel);
//			}
		}
	}

	public void DecrementHealth ()
	{
		playerHealth--;
		if(playerHealth < 0)
		{
			StartCoroutine("DecrementLives");
		}
	}

	IEnumerator DecrementLives ()
	{
		playerLives--;
		if(playerLives < 0)
		{
			GameOver();
		}
		else {
			playerHealth = storedHealth;
			invulnerable = true;
		}

		yield return new WaitForSeconds(2f);
		invulnerable = false;
	}

	public void GamePaused ()
	{
		Time.timeScale = 0.0f;
		pausedScreenPanel.SetActive(true);
	}

	public void GameResume ()
	{
		Time.timeScale = 1.0f;
		pausedScreenPanel.SetActive(false);
	}

	public void GameOver ()
	{
		playerKilled = true;
		gameOverUI.DisplayGameOver();
		SetFinalScore();
	}

	public float SetFinalScore ()
	{
		float oneSecondScore = 2 * secondsPlayerHasLasted;
		float oneMinuteScore = 120 * minutesPlayerHasLasted;
		float oneHourScore = 7200 * hoursPlayerHasLasted;
//
		float newPlayerScore = oneSecondScore + oneMinuteScore + oneHourScore;
//
//		float tempScore1 = PlayerPrefs.GetFloat("Score 1");
//		float tempScore2 = PlayerPrefs.GetFloat("Score 2");
//		float tempScore3 = PlayerPrefs.GetFloat("Score 3");
//		float tempScore4 = PlayerPrefs.GetFloat("Score 4");
//		float tempScore5 = PlayerPrefs.GetFloat("Score 5");
//
//		print(newPlayerScore);
//		print(tempScore1);
//		print(tempScore2);
//		print(tempScore3);
//		print(tempScore4);
//		print(tempScore5);
//
//		if(newPlayerScore >= PlayerPrefs.GetFloat("Score 1"))
//		{
//			PlayerPrefs.SetFloat("Score 1", newPlayerScore);
//			PlayerPrefs.SetFloat("Score 2", tempScore1);
//			PlayerPrefs.SetFloat("Score 3", tempScore2);
//			PlayerPrefs.SetFloat("Score 4", tempScore3);
//			PlayerPrefs.SetFloat("Score 5", tempScore4);
//		}
//		else if(newPlayerScore >= PlayerPrefs.GetFloat("Score 2"))
//		{
//			PlayerPrefs.SetFloat("Score 2", newPlayerScore);
//			PlayerPrefs.SetFloat("Score 3", tempScore2);
//			PlayerPrefs.SetFloat("Score 4", tempScore3);
//			PlayerPrefs.SetFloat("Score 5", tempScore4);
//		}
//		else if(newPlayerScore >= PlayerPrefs.GetFloat("Score 3"))
//		{
//			PlayerPrefs.SetFloat("Score 3", newPlayerScore);
//			PlayerPrefs.SetFloat("Score 4", tempScore3);
//			PlayerPrefs.SetFloat("Score 5", tempScore4);
//		}
//		else if(newPlayerScore >= PlayerPrefs.GetFloat("Score 4"))
//		{
//			PlayerPrefs.SetFloat("Score 4",  newPlayerScore);
//			PlayerPrefs.SetFloat("Score 5", tempScore4);
//		}
//		else if(newPlayerScore >= PlayerPrefs.GetFloat("Score 5"))
//		{
//			PlayerPrefs.SetFloat("Score 5", newPlayerScore);
//		}
//		else {
//			//return;
//		}
		return newPlayerScore;
	}
}
