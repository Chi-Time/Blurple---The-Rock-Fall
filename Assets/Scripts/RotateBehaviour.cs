using UnityEngine;
using System.Collections;

public class RotateBehaviour : MonoBehaviour {

	public float rotateSpeed;
	public float fallSpeed;
	public AnimationClip entranceAnim;
	public Animation animContro;
	public bool horizontalMovement;
	//private Rigidbody _RB;
	private SaucerController saucerContRef;
	private Vector3 movement;


	//Constructor
	void Awake ()
	{
		saucerContRef = GetComponentInParent<SaucerController>();
		//_RB = GetComponent<Rigidbody>();
		this.gameObject.SetActive(false);
	}

	// Use this for initialization
	void Start () 
	{
		if(horizontalMovement)
		{
			movement = new Vector3(-fallSpeed, 0,0);
		}
		else {
			movement = new Vector3(0, 0,-fallSpeed);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

		Vector3 rotMove = new Vector3(0,0, rotateSpeed);

		transform.Rotate(rotMove);

		transform.Translate(movement);

		//transform.Translate(0,0,-fallSpeed);

		//_RB.MoveRotation(Quaternion.Euler(move));
	}

	public void ActivateSaucer ()
	{
		this.gameObject.SetActive(true);
	}
	
	public void SaucerActivate (bool shouldActivate)
	{
		this.gameObject.SetActive(shouldActivate);
	}
	
	public void DeactivateSaucer ()
	{
		this.gameObject.SetActive(false);
	}

	void OnEnable ()
	{
		saucerContRef.beginCountDown = true;
	}

	void OnDisable ()
	{
		saucerContRef.activateTimer = 35;
	}
}
