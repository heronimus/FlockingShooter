using UnityEngine;
using System.Collections;

public class Player : Entity {

	private int levelStatus;

	public int healthLeft;
	private int enemiesLeft;
	private GameGUI gui;

	void Start(){
		gui = GameObject.FindGameObjectWithTag ("GUI").GetComponent<GameGUI> ();
		enemiesLeft = FindObjectsOfType<Enemy> ().Length;
		levelUP ();	
	}

	void Update(){

	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name.Equals ("Enemy") || collision.gameObject.name.Equals ("Enemy(Clone)")) {
			healthLeft--;
			gui.setPlayerExperience (healthLeft, enemiesLeft);
		}

	}

	public void addExperience(float exp){
		enemiesLeft--;

		gui.setPlayerExperience (healthLeft, enemiesLeft);
		Debug.Log ("health: " + healthLeft + " enemies: " + enemiesLeft);
	}

	private void levelUP(){
		levelStatus++;
		//experienceToLevel = levelStatus * 50 + Mathf.Pow (levelStatus * 2, 2);

		addExperience (0);
	}

	//Kode dari Enemy Flocking Bird
	override protected Vector3 Combine(){
		return conf.separationPriority* Separation();
	}
}
