using UnityEngine;
using System.Collections;

[System.Serializable]
public struct BoundaryConstraints
{
	public float xMin, xMax;
}

public class BlurpleController : MonoBehaviour {

	public float moveSpeed;
	public BoundaryConstraints boundaryConstraints;
	public GameObject shot;
	public Transform gunOffset;
	public float fireRate;
	public bool isUsingMouseMovement;
	
	private float nextFire;
	private Rigidbody _RB;
	private GameController gameControlRef;
	private Animator _anim;
	private CapsuleCollider collider;
	private bool isPaused;
	//private bool useMouseMovement;

	//Constructor
	void Awake ()
	{
		_RB = GetComponent<Rigidbody>();
		_anim = GetComponent<Animator>();
		gameControlRef = GetComponentInParent<GameController>();
		collider = GetComponent<CapsuleCollider>();
		this.gameObject.SetActive(true);
	}

	void Start ()
	{
		_anim.SetBool("isHurt", false);

//		if(isUsingMouseMovement)
//		{
//			useMouseMovement = true;
//		}
//		else {
//			useMouseMovement = false;
//		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isUsingMouseMovement)
		{
			PlayerMouseMovement();
		}
		else {
			PlayerMovement();
		}

		if(Input.GetButtonDown("Pause"))
		{
			isPaused = !isPaused;
		}

		if(isPaused)
		{
			gameControlRef.GamePaused();
		}
		else {
			gameControlRef.GameResume();
		}

		PlayerAnimation();
		ShootBullets();
	}

	void PlayerMovement ()
	{
		float moveH = -Input.GetAxis("Horizontal");	//Get the horizontal axis movement.
		//float moveV = Input.GetAxis("Vertical");//Get the vertical axis movement.

		//Multiply our axis movements by the movespeed parameter to affect the x, and y axis respectively.
		Vector3 movement = new Vector3(moveH * moveSpeed, 0.0f,0.0f); //moveV * moveSpeed, 0.0f);

		_RB.velocity = movement;
		_RB.position = new Vector3
			(Mathf.Clamp(_RB.position.x, boundaryConstraints.xMin, boundaryConstraints.xMax),
				 0.0f,
				 0.0f
			);
	}

	void PlayerMouseMovement ()
	{
		//Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		float mouseH = -Input.GetAxis("Mouse X");

		//float mouseH = mouse.x;

		Vector3 movement = new Vector3(mouseH * moveSpeed, 0.0f,0.0f); //moveV * moveSpeed, 0.0f);
		
		_RB.velocity = movement;
		_RB.position = new Vector3
			(Mathf.Clamp(_RB.position.x, boundaryConstraints.xMin, boundaryConstraints.xMax),
			 0.0f,
			 0.0f
			 );
	}

	void PlayerAnimation ()
	{
		if(gameControlRef.invulnerable)
		{
			_anim.SetBool("isHurt", true);
			if(_anim.GetBool("isHurt"))
			{
				collider.enabled = false;
			}
		}
		else {
			_anim.SetBool("isHurt", false);
			if(!_anim.GetBool("isHurt"))
			{
				collider.enabled = true;
			}
		}
	}

	void ShootBullets ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, gunOffset.position, gunOffset.rotation);
		}
	}
}
