using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseChangeSize : MonoBehaviour
{
    public GameObject biggest;
    public GameObject middle;
    public GameObject smallest;


    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.tag == "biggerWall")
        {
            if (smallest.gameObject.activeSelf)
            {
                smallest.gameObject.SetActive(false);
                middle.gameObject.SetActive(true);
            }

            else if (middle.gameObject.activeSelf)
            {
                middle.gameObject.SetActive(false);
                biggest.gameObject.SetActive(true);
            }


        }

        if (other.tag == "smallerWall")
        {
            if (middle.gameObject.activeSelf)
            {
                middle.gameObject.SetActive(false);
                smallest.gameObject.SetActive(true);
            }

            if (biggest.gameObject.activeSelf)
            {
                biggest.gameObject.SetActive(false);
                middle.gameObject.SetActive(true);
            }

        }

        if (other.tag == "blockWall" || other.tag == "calculater")
        {
            
          
            

            GetComponent<NodeMovement>().enabled = false;
            
            for (int i = 0; i < GetComponent<CollectCoins>().FiveCentList.Count; i++)
            {
                GetComponent<CollectCoins>().FiveCentList[i].gameObject.tag = "Untagged";
                GetComponent<CollectCoins>().FiveCentList[i].gameObject.GetComponent<BoxCollider>().enabled = true;
                GetComponent<CollectCoins>().FiveCentList[i].gameObject.GetComponent<Rigidbody>().useGravity = true;
                
            }

            if (smallest.gameObject.activeSelf)
            {
               // smallest.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        

            for (int i = 0; i < smallest.gameObject.transform.childCount; i++)
            {
                smallest.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                smallest.gameObject.transform.GetChild(i).gameObject.SetActive(true);
         


            }

            for (int i = 0; i < middle.gameObject.transform.childCount; i++)
            {
                middle.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                middle.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }

            for (int i = 0; i < biggest.gameObject.transform.childCount; i++)
            {
                biggest.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                biggest.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }

            for (int i = 3; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.GetComponent<BoxCollider>().enabled = true;
                gameObject.transform.GetChild(i).gameObject.GetComponent<Rigidbody>().useGravity = true;
            }

            yield return new WaitForSeconds(1);


       

        }

       

    }

 


}