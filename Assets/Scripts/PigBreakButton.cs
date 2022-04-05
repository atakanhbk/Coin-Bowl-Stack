using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PigBreakButton : MonoBehaviour
{
    public GameObject Hammer;


     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Collected")
        {
            transform.DOMoveY(0, 0.2f);

            Hammer.transform.DORotate(new Vector3(57, -90, transform.rotation.z), 0.3f);
        }
    }
}
