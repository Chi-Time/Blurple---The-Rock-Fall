using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {


	//Constructor
	void Awake ()
	{
		
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void StartGame ()
	{
		Application.LoadLevel(1);
	}

	public void QuitApplication ()
	{
		Application.Quit();
	}
}
