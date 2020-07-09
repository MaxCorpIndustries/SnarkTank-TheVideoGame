using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummy_follow : MonoBehaviour
{

    public float follow_speed = 1;
    //public Transform Target;

    Transform bar;

    // Start is called before the first frame update
    void Start()
    {

        bar = GameObject.Find("Player_target").transform;
    }

    void Update()
    {
        transform.position = new Vector3(bar.position.x, bar.position.y, bar.position.z);
    }
}
