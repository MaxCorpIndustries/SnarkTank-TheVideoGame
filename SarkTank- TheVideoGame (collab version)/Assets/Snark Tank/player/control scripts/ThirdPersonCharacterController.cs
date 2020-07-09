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

	public float Speed; //this will determine character speed
	public float turnSmoothTime = 0.1f;
	float turnSmoothVelocity;
    private void Start()
    {
		//initialize animator
		animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
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
