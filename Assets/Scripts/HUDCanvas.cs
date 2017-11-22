using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDCanvas : MonoBehaviour {

	public Text playerHealthText;
	public Text enemiesLeftText;
	public Slider playerHealthSlider;
	public Button RestartButton;

	Animator anim;

	int maxHealth = 0;
	int numberOfEnemies = 0;

	void Start(){	
		anim = GetComponent<Animator> ();
		RestartButton.interactable = false;
	}

	public void setMaxHealth(int argMaxHealth){
		maxHealth = argMaxHealth;
		playerHealthText.text = maxHealth+"/"+maxHealth ;
		playerHealthSlider.value = maxHealth;
	}

	public void setHealthLeft(int healthLeft){
		playerHealthText.text = healthLeft+"/"+maxHealth ;
		playerHealthSlider.value = healthLeft;
	}

	public void setMaxEnemies(int argMaxEnemies){
		numberOfEnemies = argMaxEnemies;
		enemiesLeftText.text = "Enemies Left :" + numberOfEnemies ;
	}

	public void setEnemiesLeft(){
		numberOfEnemies--;
		enemiesLeftText.text = "Enemies Left :" + numberOfEnemies ;
		if (numberOfEnemies <= 0) {
			YouWin ();
		}
	}

	public void GameOver(){
		//Debug.Log ("Anim Triggered Loose");
		RestartButton.interactable = true;
		anim.SetTrigger ("GameOver");
	}

	public void YouWin(){
		//Debug.Log ("Anim Triggered Win");
		RestartButton.interactable = true;
		anim.SetTrigger ("YouWin");
	}


}
