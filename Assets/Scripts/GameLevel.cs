using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevel : MonoBehaviour {

	public Transform enemyPrefab;
	public int numberOfEnemies;

	public List<Enemy> enemies;
	public List<Player> players;

	public float bounds;
	public float spawnRadius;
	public static float yGlobalAxis = 1f;

	HUDCanvas gui;

	void Start () {
		gui = GameObject.FindGameObjectWithTag ("GUI").GetComponent<HUDCanvas> ();
		gui.setMaxEnemies (numberOfEnemies);

		enemies = new List<Enemy>();
		players = new List<Player>();

		Spawn (enemyPrefab, numberOfEnemies-1);

		enemies.AddRange (FindObjectsOfType<Enemy> ());
		players.AddRange (FindObjectsOfType<Player> ());
	}
		
	void Spawn(Transform prefab, int count){
		for (int i = 0; i < count; i++) {
			Instantiate (prefab, new Vector3 (Random.Range(-spawnRadius,spawnRadius), yGlobalAxis, Random.Range (-spawnRadius, spawnRadius) ), Quaternion.identity);
		}
	}

	public List<Enemy> GetNeighbors(Entity enemy, float radius){
		List<Enemy> neighborsFound = new List<Enemy> ();
		foreach (var otherEnemies in enemies){
			if (otherEnemies == enemy)
				continue;

			if (Vector3.Distance (enemy.position, otherEnemies.position) <= radius) {
				neighborsFound.Add (otherEnemies);
			}
		}

		return neighborsFound;
	}


	public List<Player> GetEnemies(Entity enemy, float radius){
		List<Player> returnEnemies = new List<Player> ();
		foreach (var player in players) {
			if (Vector3.Distance (enemy.position, player.position) <= radius) {
				returnEnemies.Add (player);
			}
		}

		return returnEnemies;
	}
}
