using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Move : MonoBehaviour
{
   public Vector3 speed; //Amount of units to move per second
    public float turnSpeed;
    private float currentSpeed = 0.0f;
    public float jumpForce = 10.0f;
    private float distanceToGround = 0.0f;
    private int jumpCount = 0;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    
    private bool isJumping = false;
   // Start is called before the first frame update

    private Rigidbody rb;

   void Start()
   {
      rb = GetComponent<Rigidbody>();
      distanceToGround = GetComponent<Collider>().bounds.extents.y;
   }
 
   // Update is called once per frame
   void Update()
   {
        
   }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround + 0.1f);
        //return (Mathf.Abs(rb.velocity.y) < Mathf.Epsilon);
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

        if (Input.GetKey(KeyCode.F))
        {
            GameObject newBullet = GameObject.Instantiate(bullet, bulletSpawnPoint.position, new Quaternion());
            Rigidbody bulletBody = newBullet.GetComponent<Rigidbody>();
            bulletBody.AddForce(transform.forward * 30, ForceMode.Impulse);
        }

        //Speed is a Vector3 defines how fast to move in 3D space
        gameObject.transform.Rotate(Vector3.up, currentTurnAmount * Time.deltaTime);
        rb.AddForce(transform.forward * currentSpeed * Time.deltaTime, ForceMode.Impulse);
        
        bool isGrounded = IsGrounded();

        if (isGrounded)
        {
            jumpCount = 0;
        }
        if (Input.GetKeyUp(KeyCode.Space) && (isGrounded || jumpCount < 2))
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount = jumpCount + 1;
        }

        rb.angularVelocity = Vector3.zero;
    }
}