using UnityEngine;
using System.Collections;

public class SaucerController : MonoBehaviour {

	[SerializeField]public float deactivateTimer = 2;
	[SerializeField]public float activateTimer = 35;
	[SerializeField]public bool beginCountDown;
	//public bool shouldDeactivate = true;
	public RotateBehaviour rotateRef;

	//Constructor
	void Awake ()
	{
		//rotateRef = GetComponentInChildren<RotateBehaviour>();
		beginCountDown = false;
	}

	// Update is called once per frame
	void Update () 
	{
		activateTimer -= Time.deltaTime;

		if(activateTimer <= 0)
		{
			activateTimer = 35;
			rotateRef.ActivateSaucer();
		}
	}
}
