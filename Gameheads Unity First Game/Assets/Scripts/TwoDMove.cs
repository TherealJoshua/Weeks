using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDMove : MonoBehaviour
{
    public Vector3 speed;
    private float currentSpeed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            currentSpeed = speed.x;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentSpeed = speed.x;
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed = speed.y;
        }
    }
}
