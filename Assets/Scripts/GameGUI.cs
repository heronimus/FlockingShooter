using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	public TextMesh Level;
	public TextMesh Exp;

	public void setPlayerExperience(int healthLeft, float enemiesLeft){
		Level.text = "Health : "+ healthLeft ;
		Exp.text = "Enemies Left :" + enemiesLeft ;
	}


}
