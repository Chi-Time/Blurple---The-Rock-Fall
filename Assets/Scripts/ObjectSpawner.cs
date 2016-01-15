using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour {

	[Tooltip("The GameObjects you want to spawn")]
	public GameObject[] objects;
	//public List<GameObject> spawnedObjects;
	[Tooltip("The Transform positions you want the objects to spawn at.")]
	public Transform[] spawnPositions;
	[Tooltip("The Transform positions you want the objects to spawn at.")]
	public Transform spawnHorizontalPosition;
	[Tooltip("How long between inital object spawns")]
	public float delayTime;
	[Tooltip("The maximum amount of objects you want in scene.")]
	public int amountOfObjects;
	private int currentObjectCount = 0;

	//Constructor
	void Awake ()
	{
		
	}
	
	void Start () 
	{
//		for(int i = 0; i < amountOfObjects; i++)
//		{
//			GameObject clone = Instantiate(objects[Random.Range(0,2)], new Vector3(Random.Range(-6,6), 10.0f, 0.0f), Quaternion.identity) as GameObject;
//			clone.SetActive(false);
//			spawnedObjects.Insert(i, clone);
//		}
		StartCoroutine("SpawnObject");
	}

	IEnumerator SpawnObject ()
	{
		yield return new WaitForSeconds(delayTime);
		if(currentObjectCount <= amountOfObjects)
		{
			Instantiate(objects[Random.Range(0,2)], spawnPositions[Random.Range(0,16)].position, Quaternion.identity);
			currentObjectCount++;
		}
		StartCoroutine("SpawnObject");
//		yield return new WaitForSeconds(delayTime);
//		for(int i = 0; i < spawnedObjects.Count; i++)
//		{
//			spawnedObjects[i].gameObject.SetActive(true);
//		}
//		Instantiate(objects[Random.Range(0,2)], spawnPositions[Random.Range(0,16)].position, Quaternion.identity);
//		StartCoroutine("SpawnObject");
	}
	
}
