using UnityEngine;
using System.Collections;

public class DestroyBullets : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		if(other.CompareTag("Bullet"))
		{
			Destroy(other.gameObject);
		}
		else {
			return;
		}
	}
}
