using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
	
	public float Speed; //this will determine character speed

    // Update is called once per frame
    void Update()
    {
		PlayerMovement(); //call PlayerMovement in update
    }
	
	void PlayerMovement()
	{
		//assign movement positions to float variables
		float hor = -Input.GetAxis("Horizontal");
		float ver = -Input.GetAxis("Vertical");
		
		//implement input into moving player
		Vector3 PlayerMovement = new Vector3(hor,0f,ver) * Speed * Time.deltaTime;
		
		//actualling moving the player
		transform.Translate(PlayerMovement, Space.Self);

	if (Input.GetKeyDown(KeyCode.LeftAlt))
	{
		print("alt key was pressed");
	}

	}
}
