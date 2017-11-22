using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : Entity {

	private int levelStatus;
	private HUDCanvas gui;


	//Health & Attack
	public int healthLeft = 10;
	public float timeBetweenAttacks = 3f;
	float timer;
	bool enemiesInTouch;
	public Image damageImage;
	public float flashSpeed = 15f; 
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);  

	void Start(){
		gui = GameObject.FindGameObjectWithTag ("GUI").GetComponent<HUDCanvas> ();
		gui.setMaxHealth (healthLeft);

	}

	void Update(){
		timer += Time.deltaTime;
	
		if (timer >= timeBetweenAttacks && enemiesInTouch) {
			healthLeft--;
			gui.setHealthLeft (healthLeft);
			if (healthLeft <= 0) {
				Debug.Log ("Game Over ...");
				gui.GameOver ();

				Die ();
			}
			damageImage.color = flashColour;
			timer = 0;
		}
		damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag.Equals ("Enemy")) {
			enemiesInTouch = true;
		}
	}
	void OnCollisionExit(Collision collision){
		if (collision.gameObject.tag.Equals ("Enemy")) {
			enemiesInTouch = false;
		}
	}

	public void KillEnemy(){
		gui.setEnemiesLeft();
	}
		
	override protected Vector3 Combine(){
		return conf.separationPriority* Separation();
	}
}
