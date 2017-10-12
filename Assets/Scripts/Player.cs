using UnityEngine;
using System.Collections;

public class Player : Entity {

	private int levelStatus;
	private float currentLevelExperience;
	private float experienceToLevel;

	private GameGUI gui;

	void Start(){
		gui = GameObject.FindGameObjectWithTag ("GUI").GetComponent<GameGUI> ();
		levelUP ();	
	}

	void Update(){

	}

	public void addExperience(float exp){
		currentLevelExperience += exp;
		if (currentLevelExperience >= experienceToLevel) {
			currentLevelExperience -= experienceToLevel;
			levelUP();
		}

		gui.setPlayerExperience (levelStatus, experienceToLevel-currentLevelExperience);
		Debug.Log ("exp: " + currentLevelExperience + " level: " + levelStatus);
	}

	private void levelUP(){
		levelStatus++;
		experienceToLevel = levelStatus * 50 + Mathf.Pow (levelStatus * 2, 2);

		addExperience (0);
	}

	//public Vector3 position;
	override protected Vector3 Combine(){
		return conf.separationPriority* Separation();
	}
}
