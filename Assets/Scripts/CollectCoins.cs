using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    int i = 0;
    public List<Transform> trans;
    public GameObject FiveCent;
    public List<GameObject> FiveCentList;

    public float myMoney = 0;
    private void Update()
    {
        if (GetComponent<VaseChangeSize>().smallest.activeSelf && i > 20)
        {
            i--;
            Destroy(FiveCentList[i].gameObject);
            for (var a = FiveCentList.Count - 1; a > -1; a--)
            {
                if (FiveCentList[a] == null)
                    FiveCentList.RemoveAt(a);
            }

        }

        if (GetComponent<VaseChangeSize>().middle.activeSelf && i > 40)
        {
            i--;
            Destroy(FiveCentList[i].gameObject);

            for (var a = FiveCentList.Count - 1; a > -1; a--)
            {
                if (FiveCentList[a] == null)
                    FiveCentList.RemoveAt(a);
            }

        }

        if (GetComponent<VaseChangeSize>().middle.activeSelf && i > 60)
        {
            i--;
            Destroy(FiveCentList[i].gameObject);
            for (var a = FiveCentList.Count - 1; a > -1; a--)
            {
                if (FiveCentList[a] == null)
                    FiveCentList.RemoveAt(a);
            }

        }
      


        myMoney =  0.5f*FiveCentList.Count;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "5cent")
        {
         
            if (GetComponent<VaseChangeSize>().smallest.activeSelf)
            {
                if (i < 20)
                {
                    var spawned = Instantiate(FiveCent, trans[i].transform.position, trans[i].transform.rotation);
                    FiveCentList.Add(spawned);
                    spawned.transform.parent = gameObject.transform;
                    i++;
                }


            }

            if (GetComponent<VaseChangeSize>().middle.activeSelf)
            {
                if (i < 40)
                {

                    var spawned = Instantiate(FiveCent, trans[i].transform.position, trans[i].transform.rotation);
                    FiveCentList.Add(spawned);
                    spawned.transform.parent = gameObject.transform;
                    i++;
                }


            }

            if (GetComponent<VaseChangeSize>().biggest.activeSelf)
            {
                if (i < 60 )
                {
                    var spawned = Instantiate(FiveCent, trans[i].transform.position, trans[i].transform.rotation);
                    FiveCentList.Add(spawned);
                    spawned.transform.parent = gameObject.transform;
                    i++;
                }
                
            }


        }

     


    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pig5cent")
        {
            Destroy(other.gameObject);
            var spawned = Instantiate(FiveCent, trans[i].transform.position, trans[i].transform.rotation);
            FiveCentList.Add(spawned);
            spawned.transform.parent = gameObject.transform;
            i++;
        }
    }


}