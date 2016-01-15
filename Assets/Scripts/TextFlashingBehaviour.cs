using UnityEngine;
using System.Collections;

public class TextFlashingBehaviour : MonoBehaviour {

	public GameObject pausedTextGO;
	public float ha;
	[SerializeField]private float timer = 2;
	[SerializeField]private bool isActive;

	//Constructor
	void Awake ()
	{
		pausedTextGO.SetActive(true);
		isActive = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		ha = Time.deltaTime;
		timer -= Time.deltaTime;

		if(timer <= 0)
		{
			isActive = !isActive;
			timer = 2;
		}

		if(isActive)
		{
			pausedTextGO.SetActive(true);
		}
		else{
			pausedTextGO.SetActive(false);
		}
	}
}
