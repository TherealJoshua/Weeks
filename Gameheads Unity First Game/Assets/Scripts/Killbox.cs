using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour
{
    public Transform spawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CapsulePlayer") )
        {
            Debug.Log("Player hit me!");

            other.gameObject.transform.position = spawnPoint.position;
        }
    }

}
