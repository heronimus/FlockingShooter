using UnityEngine;
using System.Collections;

public class Player : Entity {

	private int level;
	private float currentLevelExperience;
	private float experienceToLevel;

	private GameGUI gui;

	void Start(){
		gui = GameObject.FindGameObjectWithTag ("GUI").GetComponent<GameGUI> ();
		levelUP ();	
	}

	public void addExperience(float exp){
		currentLevelExperience += exp;
		if (currentLevelExperience >= experienceToLevel) {
			currentLevelExperience -= experienceToLevel;
			levelUP();
		}

		gui.setPlayerExperience (level, experienceToLevel-currentLevelExperience);
		Debug.Log ("exp: " + currentLevelExperience + " level: " + level);
	}

	private void levelUP(){
		level ++;
		experienceToLevel = level * 50 + Mathf.Pow (level * 2, 2);

		addExperience (0);
	}
}
