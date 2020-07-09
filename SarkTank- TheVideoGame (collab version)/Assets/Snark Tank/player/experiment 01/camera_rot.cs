using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_rot: MonoBehaviour
{
	public float RotationSpeed=1;
	float mouseX,mouseY;

	[SerializeField]
	Transform focus = default;

	[SerializeField, Range(1f, 20f)]
	float distance = 5f;

	// Start is called before the first frame update
	void Start()
    {
		Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	void Update()
	{
		CamControl();
		
	}
	
	void CamControl()
	{
		mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
		mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
		mouseY = Mathf.Clamp(mouseY, -10, 20);
		
	}
}
