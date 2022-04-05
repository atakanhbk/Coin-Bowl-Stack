using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectController : MonoBehaviour
{
    GameObject GameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            GameManager = GameObject.FindGameObjectWithTag("GameManager");
            GameManager.GetComponent<GameManeger>().trigger = true;
            other.gameObject.transform.position = transform.position + Vector3.forward;
            other.gameObject.AddComponent<CollectController>();
            // other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            Destroy(gameObject.GetComponent<CollectController>());
            other.gameObject.AddComponent<NodeMovement>();
            other.gameObject.GetComponent<NodeMovement>().connectedNode = transform;
            other.gameObject.tag = "Collected";

        }




    }


}