using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool canRotateAround = false;

    // Update is called once per frame
    void Update()
    {
       

        if (canRotateAround)
        {
            transform.RotateAround(target.transform.position,
        new Vector3(0, 1, 0), 70 * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, 2 * Time.deltaTime);
        }
    }
}
