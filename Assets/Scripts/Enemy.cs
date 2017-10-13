using UnityEngine;
using System.Collections;

public class Enemy : Entity {

	public float expOnDeath;
	private Player player;


	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

		level = FindObjectOfType<GameLevel> ();
		conf = FindObjectOfType<EntityConfig> ();

		position = transform.position;
		velocity = new Vector3 (Random.Range (-3, 3), 0 , Random.Range (-3, 3));

	}

	public override void Die(){
		player.addExperience (expOnDeath);
		base.Die ();
	}

	//Untuk Enemy (Kotak Merah) Gerak setiap saat
	// * dari kode Member di Flocking Bird
	void Update(){
		acceleration = Combine ();
		acceleration = Vector3.ClampMagnitude (acceleration, conf.maxAcceleration);
		velocity = velocity + acceleration * Time.deltaTime;
		velocity = Vector3.ClampMagnitude (velocity, conf.maxVelocity);
		position = position + velocity * Time.deltaTime;
		WrapAround(ref position, -level.bounds, level.bounds);
		position.y = yGlobalAxis;
	
		transform.position = position;
	}

}
