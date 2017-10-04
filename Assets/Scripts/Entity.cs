using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
	public float health;

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
}
