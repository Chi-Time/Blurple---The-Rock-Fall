using UnityEngine;
using System.Collections;

public class KillBoundary : MonoBehaviour {
	
	private ObjectSpawner objectSpawnRef;

	void Awake ()
	{
		objectSpawnRef = GetComponentInParent<ObjectSpawner>();
	}

	void OnTriggerEnter (Collider other)
	{
		other.gameObject.transform.position = objectSpawnRef.spawnPositions[Random.Range(0,16)].position;
		other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);

		if(other.gameObject.CompareTag("Saucer"))
		{
			other.gameObject.transform.position = objectSpawnRef.spawnPositions[Random.Range(0,16)].position;
			other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
			other.gameObject.SetActive(false);
		}

		if(other.gameObject.CompareTag("SaucerH"))
		{
			other.gameObject.transform.position = objectSpawnRef.spawnHorizontalPosition.position;
			other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
			other.gameObject.SetActive(false);
		}
	}
}
