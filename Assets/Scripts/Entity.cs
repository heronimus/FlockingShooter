using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
	public float health;

	public Vector3 position;
	public Vector3 velocity;
	public Vector3 acceleration;

	public GameLevel level;
	public EntityConfig conf;

	Vector3 wanderTarget;

	public static float yGlobalAxis = 1f;

	public virtual void takeDamage(float dmg){
		health -= dmg;

		Debug.Log (health);

		if (health <= 0) {
			Die();
		}

	}

	public virtual void Die(){
		Debug.Log ("Dead");
		Destroy (gameObject);
	}

	/* *
	 * 
	 * 
	 * */

	//Kode Dari Member di Flocking Bird untuk ngejauhin player.

	protected Vector3 Wander(){
		float jitter = conf.wanderJitter * Time.deltaTime;
		wanderTarget += new Vector3(RandomBinomial()*jitter, yGlobalAxis, RandomBinomial()*jitter);
		wanderTarget = wanderTarget.normalized;
		wanderTarget *= conf.wanterRadius;
		Vector3 targetInLocalSpace = wanderTarget + new Vector3 (conf.wanterDistance, yGlobalAxis, conf.wanterDistance);
		Vector3 targetInWorldSpace = transform.TransformPoint(targetInLocalSpace);
		targetInWorldSpace -= this.position;
		return targetInWorldSpace.normalized;
	}
		

	protected Vector3 RunAway(Vector3 target){
		Vector3 neededVelocity = (position - target).normalized * conf.maxVelocity;
		return neededVelocity - velocity;
	}

	Vector3 Cohesion(){
		Vector3 cohesionVector = new Vector3 ();
		int countMembers = 0;
		var neighbors = level.GetNeighbors (this, conf.cohesionRadius);
		if (neighbors.Count == 0) {
			return cohesionVector;
		}
		foreach (var member in neighbors) {
			if (isInFOV (member.position)) {
				cohesionVector += member.position;
				countMembers++;
			}
		}

		if (countMembers == 0) {
			return cohesionVector;
		}

		cohesionVector /= countMembers;

		cohesionVector = cohesionVector - this.position;
		cohesionVector = Vector3.Normalize (cohesionVector);
		return cohesionVector;
	}


	Vector3 Alignment(){
		Vector3 alignVector = new Vector3 ();
		var members = level.GetNeighbors (this, conf.alignmentRadius);
		if (members.Count == 0)
			return alignVector;

		foreach (var member in members) {
			if (isInFOV (member.position))
				alignVector += member.velocity;
		}

		return alignVector.normalized;

	}

	protected Vector3 Separation(){
		Vector3 separateVector = new Vector3 ();
		var members = level.GetNeighbors (this, conf.separationRadius);
		if (members.Count == 0)
			return separateVector;

		foreach (var member in members){
			if(isInFOV(member.position)){
				Vector3 movingTowards = this.position - member.position;
				if (movingTowards.magnitude > 0){
					separateVector += movingTowards.normalized / movingTowards.magnitude;
				}
			}

		}
		return separateVector.normalized;
	}

	Vector3 Avoidance(){
		Vector3 avoidVector = new Vector3 ();
		var enemyList = level.GetEnemies (this, conf.avoidanceRadius);
		if (enemyList.Count == 0)
			return avoidVector;

		foreach (var enemy in enemyList) {
			avoidVector += RunAway (enemy.position);

		}
		return avoidVector.normalized;
	}

	virtual protected Vector3 Combine(){
		Vector3 finalVec = conf.cohesionPriority * Cohesion () + conf.wanterPriority * Wander ()+conf.alignmentPriority*Alignment()+ conf.separationPriority*Separation()+conf.avoidancePriority*Avoidance();
		return finalVec;
	}


	protected void WrapAround(ref Vector3 vector, float min, float max){
		vector.x = WrapAroundFloat (vector.x, min, max);
		vector.y = WrapAroundFloat (vector.y, min, max);
		vector.z = WrapAroundFloat (vector.z, min, max);
	}


	protected float WrapAroundFloat(float value, float min, float max){
		if (value > max)
			value = min;
		else if (value < min)
			value = max;
		return value;
	}

	protected float RandomBinomial(){
		return Random.Range (0f, 1f) - Random.Range (0f, 1f);
	}

	protected bool isInFOV(Vector3 vec){
		return Vector3.Angle (this.velocity, vec - this.position) <= conf.maxFOV;
	}



}
