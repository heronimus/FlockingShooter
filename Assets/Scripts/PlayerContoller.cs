using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;



[RequireComponent (typeof (CharacterController))]

public class PlayerContoller : MonoBehaviour {
	public float rotationSpeed = 450;
	public float walkSpeed = 5;
	public float runSpeed = 8;

	private Quaternion targetRotation;


	private CharacterController controller;
	private Camera cam;

	public Gun gun;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		controlWASD ();
		controlTouch ();
		if (Input.GetButtonDown ("Shoot") || CrossPlatformInputManager.GetButtonDown ("Shoot")) {
			gun.Shoot();
		}

	}
	void controlTouch(){
		//mendapatkan posisi inputnya
		Vector3 input = new Vector3(CrossPlatformInputManager.GetAxisRaw("Horizontal"),0,CrossPlatformInputManager.GetAxisRaw("Vertical"));
		//menggerakkan object gamenya
		if (input != Vector3.zero) {
			targetRotation = Quaternion.LookRotation (input);
			transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y,rotationSpeed * Time.deltaTime);
		}
		
		Vector3 motion = input;
		//Kecepatan jalan
		motion *= (Mathf.Abs (input.x) == 1 && Mathf.Abs (input.z) == 1) ? .7f:1;
		motion *= (Input.GetButton ("Run")) ? runSpeed : walkSpeed;
		//Gravitasi
		motion += Vector3.up * -8;
		//Jalan
		controller.Move(motion * Time.deltaTime);
	}

	void controlWASD(){
		//mendapatkan posisi inputnya
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
		//menggerakkan object gamenya
		if (input != Vector3.zero) {
			targetRotation = Quaternion.LookRotation (input);
			transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y,rotationSpeed * Time.deltaTime);
		}
		
		Vector3 motion = input;
		//Kecepatan jalan
		motion *= (Mathf.Abs (input.x) == 1 && Mathf.Abs (input.z) == 1) ? .7f:1;
		motion *= (Input.GetButton ("Run")) ? runSpeed : walkSpeed;
		//Gravitasi
		motion += Vector3.up * -8;
		//Jalan
		controller.Move(motion * Time.deltaTime);
	}

	void controlMouse(){
		Vector3 mousePos = Input.mousePosition;

		mousePos = cam.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));
		targetRotation = Quaternion.LookRotation (mousePos - new Vector3(transform.position.x,0,transform.position.z));
		transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y,rotationSpeed * Time.deltaTime);

		//mendapatkan posisi inputnya
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
		//menggerakkan object gamenya
		
		Vector3 motion = input;
		//Kecepatan jalan
		motion *= (Mathf.Abs (input.x) == 1 && Mathf.Abs (input.z) == 1) ? .7f:1;
		motion *= (Input.GetButton ("Run")) ? runSpeed : walkSpeed;
		//Gravitasi
		motion += Vector3.up * -8;
		//Jalan
		controller.Move(motion * Time.deltaTime);
		//Posisi Mouse
		//Debug.Log (mousePos);
	}
}