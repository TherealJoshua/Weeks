using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    public float followDistance;
    public float cameraFollowSpeed = 0.1f;
    public Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetPosition = target.transform.position;

        Vector3 followVector = transform.forward * -followDistance;

        transform.position = targetPosition + followVector;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentSpeed = Vector3.zero;
        
        Vector3 targetPosition = target.transform.position;

        Vector3 followVector = transform.forward * -followDistance;

        Vector3 cameraTargetPosition = targetPosition + followVector;

        transform.position = Vector3.Lerp(transform.position, cameraTargetPosition, cameraFollowSpeed * Time.deltaTime);

         Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.up);
        
        if (angle < 5.0f)
        {
            print("close");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
       {
           currentSpeed.x = -speed.x;
       }
        if (Input.GetKey(KeyCode.RightArrow))
       {
           currentSpeed.x = speed.x;
       }
    }
        
}
