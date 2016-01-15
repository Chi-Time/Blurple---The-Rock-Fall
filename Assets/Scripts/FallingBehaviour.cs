using UnityEngine;
using System.Collections;

public class FallingBehaviour : MonoBehaviour {

	public float moveSpeed;
	public float fallSpeed;
	private Rigidbody _RB;

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
		transform.Translate(Vector3.up * -moveSpeed);
		transform.Translate(Vector3.right * -fallSpeed);
	}
}
