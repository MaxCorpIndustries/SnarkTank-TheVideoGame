using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{

	private Animator animator;
	public CharacterController controller;
	public Transform cam;
	

	public float DefaultSpeed = 10f; //this will determine character speed
	public float Speed; //this will determine character speed
	public float run;
	public float croutch;
	public float croutch_speed_subtract=10;
	public float croutch_speed_impact;
	public float turnSmoothTime = 0.1f;
	float turnSmoothVelocity;
	

	private void Start()
    {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		//initialize animator
		animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
		//check if shift is pressed
		if (Input.GetKey(KeyCode.LeftShift))
		{
			run = 1;
			Speed = DefaultSpeed+10- croutch_speed_impact;
		}
		else {
			run = 0;
			Speed = DefaultSpeed- croutch_speed_impact;
		}

		//check if shift is pressed
		if (Input.GetKey(KeyCode.LeftControl))
		{
			croutch_speed_impact = croutch_speed_subtract;
			croutch = 1;
		}
		else
		{
			croutch_speed_impact = 0;
			croutch = 0;
		}

		//apply running animation to shift
		animator.SetFloat("Running", run);
		animator.SetFloat("Croutching", croutch);

		//assign movement positions to float variables
		float hor = Input.GetAxisRaw("Horizontal");
		float ver = Input.GetAxisRaw("Vertical");

		//apply user input to animator parameters 'horizontal' and 'vertcial'
		animator.SetFloat("Horizontal", hor);
		animator.SetFloat("Vertical", ver);

		//apply input to direction vector
		Vector3 direction = new Vector3(hor, 0f, ver).normalized;

		if (direction.magnitude >= .1f)
		{
			//get angle between angle 0 degrees and the angle of the player (outputs angle in radians)
			float targetAngle = (Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y);
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			//update controller to move player
			controller.Move(moveDir.normalized * Speed * Time.deltaTime);
	
		}
    }
}
