using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	public Transform enemyPrefab;
	public int numberOfEnemies;
	public List<Enemy> enemies;
	public float bounds;
	public float spawnRadius;

	// Use this for initialization
	void Start () {
		enemies = new List<Enemy> ();

		//Spawn Members
		Spawn (enemyPrefab, numberOfEnemies);
		//enemies.AddRange(FindObjectOfType<Enemy> ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn(Transform prefab, int count)
	{
		for (int i = 0; i < count; i++) {
			Instantiate(prefab, new Vector3((float) Random.Range(-spawnRadius,spawnRadius),(float) 0.5, (float) 0),
				Quaternion.identity);
		}
	}	
}
