using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeSpan = 3.0f;
    public float currentLife = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        currentLife = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //When 3 seconds has past, delete me
        //Hint: Time.deltaTime
        lifeSpan += Time.deltaTime;
        currentLife = lifeSpan * Time.deltaTime;
        //Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
    Destroy(GameObject(Bullet));
    }
}
