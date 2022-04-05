using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
        transform.Translate(0,0, movementSpeed * Time.deltaTime);
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "calculater")
        {

            movementSpeed = 0;
        }
    }
}
