using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerOpen : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        // other.gameObject.GetComponent<BoxCollider>().isTrigger = true;

        if (other.gameObject.tag == "pig5cent")
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            

            //other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }

      
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "pig5cent")
        {
            collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
        
    }
}
