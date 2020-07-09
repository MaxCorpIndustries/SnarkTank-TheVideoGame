using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ---------- EXPERIMENT 02 ----------
 * 
 * This code will attempt to mimick freelook third person systems as seen in watch dogs
 * 
 * 
 * 
*/


public class player_movement : MonoBehaviour
{
    //setting up vars

         //player rotation 
         int direction = 0;
         float player_movementspeed = 10;

        //camera rotation vars 
        float camera_rotation_x, camera_rotation_y;
    
        //mouse rotation and speed control
        float mouseX, mouseY;
        public float RotationSpeed = 1;

        //define camera object
        Camera cam;

        //define pivot as a game object
        public GameObject pivot;

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 rot;

        //Note: (switch statement doesn't work for this)
        if (Input.GetKeyDown(KeyCode.W))
        {
            //foward
            direction = 1;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            //backward
            direction = 2;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            //left
            direction = 3;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            //right
            direction = 4;
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            //idle
            direction = 0;
        }

        print(direction);


        switch (direction)
        {
            case 0: //idle state
                //update animations
                //anim.SetInteger("State", 0);
                break;
            case 1: //moving forward state
                    //update animations
                    //anim.SetInteger("State", 1);

                rot = gameObject.transform.localEulerAngles;
                rot.y = pivot.transform.localEulerAngles.y;

                gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(rot), 5f * Time.deltaTime);
                gameObject.transform.Translate(0, 0, 20 * Time.deltaTime);

                pivot.transform.position = Vector3.Slerp(pivot.transform.position, gameObject.transform.position, 5f * Time.deltaTime);
                break;
        } //end switch statement

    }//end void update

}//end public class

public class PivotControl : MonoBehaviour
{
    float rotationY = 0F;
    Camera cam;
    //Text label;

    // Use this for initialization
    void Start()
    {
        cam = gameObject.GetComponentInChildren<Camera>();
        //label = GameObject.Find("Label").GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            float rotationX = gameObject.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * 2f;

            rotationY += Input.GetAxis("Mouse Y") * 5f;
            gameObject.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            cam.transform.LookAt(cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cam.farClipPlane)));
            //check if we are looking at something we can interact with                
            RaycastHit hit;
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "Interactable")
                {
                    //label.text = "Press E to interact with " + hit.collider.name;
                }
            }
            else
            {
                //label.text = "";
            }

        }//end getaxis if statement

    }//end void update

}//end pivotcontrol class
