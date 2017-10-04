using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameGUI : MonoBehaviour {

	public TextMesh Level;
	public TextMesh Exp;



	public void setPlayerExperience(int playerLevel, float playerExperience){
		Level.text = "Level : "+ playerLevel ;
		Exp.text = "Experience Left: " + playerExperience ;

	}
		
}
