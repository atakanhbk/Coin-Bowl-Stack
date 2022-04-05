using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PigBreak : MonoBehaviour
{
    public GameObject coin;
    public List<GameObject> coinList;

    float randomPosX;
    float randomPosZ;
    void Start()
    {
        
    }

 
    void Update()
    {
        StartCoroutine(deleteObjects());
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.tag=="hammer")
        {
            for (int i = 1; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
              
            }

            for (int i = 0; i < 20; i++)
            {
                
                
                var spawnCoin = Instantiate(coin, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
                coinList.Add(spawnCoin);
                coinList[i].transform.DOMove(new Vector3(Random.Range(-transform.position.x, transform.position.x), transform.position.y, Random.Range(transform.position.z+5, transform.position.z + 10)),0.5f);
               
            }
        }
    }

    IEnumerator deleteObjects()
    {
        if (gameObject.transform.GetChild(0).gameObject.activeSelf == false)
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
    }
}
