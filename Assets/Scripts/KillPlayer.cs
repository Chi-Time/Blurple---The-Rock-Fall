using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	private GameController gameControlRef;

	void Awake ()
	{
		gameControlRef = GameObject.Find("GameController").GetComponent<GameController>();
	}

	void OnCollisionEnter (Collision other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			gameControlRef.DecrementHealth();
			if(gameControlRef.playerKilled)
			{
				other.gameObject.SetActive(false);
			}
		}
	}
}
