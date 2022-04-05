using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class NodeMovement : MonoBehaviour
{
   
    public Transform connectedNode;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, connectedNode.position.x, Time.deltaTime * 10),
            connectedNode.position.y,
            connectedNode.position.z + 2
            );
    }

     void OnTriggerEnter(Collider other)
    {
        /*
        if (other.gameObject.tag == "throwCase")
        {
            gameObject.tag = "Collect";
            connectedNode = null;
            gameObject.transform.DOMove(new Vector3(Random.Range(-6, 0), transform.position.y, Random.Range(transform.position.z + 5, transform.position.z + 20)), 2);
            //gameObject.AddComponent<CollectController>();
            GameObject.FindGameObjectWithTag("Player").AddComponent<CollectController>();
        }
        */
    }
}
