using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour {

	public Transform memberPrefab;
	public Transform enemyPrefab;

	public int numberOfMembers;
	public int numberOfEnemies;

	public List<Enemy> members;
	public List<Player> enemies;

	public float bounds;
	public float spawnRadius;
	public static float yGlobalAxis = 0.48f;


	void Start () {
		members = new List<Enemy>();
		enemies = new List<Player>();

		Spawn (memberPrefab, numberOfMembers);
		Spawn (enemyPrefab, numberOfEnemies);

		members.AddRange (FindObjectsOfType<Enemy> ());
		enemies.AddRange (FindObjectsOfType<Player> ());
	}

	void Spawn(Transform prefab, int count){
		for (int i = 0; i < count; i++) {
			Instantiate (prefab, new Vector3 (Random.Range(-spawnRadius,spawnRadius), yGlobalAxis, Random.Range (-spawnRadius, spawnRadius) ), Quaternion.identity);
		}
	}

	public List<Enemy> GetNeighbors(Entity member, float radius){
		List<Enemy> neighborsFound = new List<Enemy> ();
		foreach (var otherMember in members)
		{
			if (otherMember == member)
				continue;

			if (Vector3.Distance (member.position, otherMember.position) <= radius) {
				neighborsFound.Add (otherMember);
			}
		}

		return neighborsFound;
	}


	public List<Player> GetEnemies(Entity member, float radius){
		List<Player> returnEnemies = new List<Player> ();


		foreach (var enemy in enemies) {
			if (Vector3.Distance (member.position, enemy.position) <= radius) {
				returnEnemies.Add (enemy);
			}


		}
		return returnEnemies;
	}
}
