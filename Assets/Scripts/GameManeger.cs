using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManeger : MonoBehaviour
{
    public bool trigger = false;
    public GameObject[] caseList;
    GameObject[] number5cent;
    public Text moneyText;
    
    public int moneyCount = 0;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        caseList = GameObject.FindGameObjectsWithTag("Collected");
        number5cent = GameObject.FindGameObjectsWithTag("5centCoin");
        moneyCount = (number5cent.Length*5)/10;
        moneyText.text = "$" + moneyCount;
        



        if (trigger)
        {
            StartCoroutine(WaveEffect());
            trigger = false;
        }
    }

    IEnumerator WaveEffect()
    {
        
            for (int i = 1; i < caseList.Length + 1; i++)
            {
                var lastCup = caseList[caseList.Length - i];
                lastCup.transform.DOScale(1.35f, 0.125f);
                yield return new WaitForSeconds(0.1f);
                lastCup.transform.DOScale(1.0f, 0.125f);
            }
      
    }
}
