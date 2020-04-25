using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Move : MonoBehaviour
{
   public Vector3 speed; //Amount of units to move per second
    public float turnSpeed;
    public float jumpForce = 10.0f;
    
    private bool isJumping = false;
   // Start is called before the first frame update

    private Rigidbody rb;

   void Start()
   {
      rb = GetComponent<Rigidbody>();
   }
 
   // Update is called once per frame
   void Update()
   {
        
   }


    void FixedUpdate()
    {
    float currentSpeed = 0.0f;
        float currentTurnAmount = 0.0f;

        if (Input.GetKey(KeyCode.A))
        {
            currentTurnAmount -= turnSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentTurnAmount += turnSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed = speed.x;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentSpeed = -speed.x;
        }

       //Speed is a Vector3 defines how fast to move in 3D space
        gameObject.transform.Rotate(Vector3.up, currentTurnAmount * Time.deltaTime);
        rb.AddForce(transform.forward * currentSpeed * Time.deltaTime, ForceMode.Impulse);

        if (Input.GetKeyUp(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        rb.angularVelocity = Vector3.zero;
    }
}