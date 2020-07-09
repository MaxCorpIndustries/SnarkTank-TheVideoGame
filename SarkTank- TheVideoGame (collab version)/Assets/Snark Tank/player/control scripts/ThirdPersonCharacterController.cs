using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{

	private Animator animator;

	public float Speed; //this will determine character speed

    private void Start()
    {
		//initialize animator
		animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
		PlayerMovement(); //call PlayerMovement in update
    }
	
	void PlayerMovement()
	{
		//assign movement positions to float variables
		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis("Vertical");


		//apply user input to animator parameters 'horizontal' and 'vertcial'
		animator.SetFloat("Horizontal", hor);
		animator.SetFloat("Vertical", ver);

		//implement input into moving player
		Vector3 PlayerMovement = new Vector3(hor,0f,ver) * Speed * Time.deltaTime;
		
		//actualling moving the player
		transform.Translate(PlayerMovement, Space.Self);



	}
}
