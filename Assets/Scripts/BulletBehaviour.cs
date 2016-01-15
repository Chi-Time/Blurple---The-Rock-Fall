using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

	public float fireSpeed;

	void Start ()
	{
		Destroy(this.gameObject, 2f);
	}

	void Update ()
	{
		//Vector3 fireMovement = new Vector3(0,0,fireSpeed);
		transform.Translate(Vector3.forward * fireSpeed);
	}

	void OnCollisionEnter (Collision other)
	{
		if(other.gameObject.CompareTag("Saucer"))
		{
			Destroy(other.gameObject);
		}
		else {
			return;
		}
	}
}
