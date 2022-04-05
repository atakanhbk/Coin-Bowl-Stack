using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Calculater : MonoBehaviour
{


    public Text collectedMoneyText;
    public int collectedMoneyCount = 0;
    public float _radius;

    public Material bearMaterial;
    public GameObject stick;
    bool startPaint = false;
    float paintBear = 0;

    public GameObject bear;

    public Transform podium;
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        bearMaterial.SetFloat("_Radius", 0);
        bearMaterial.SetVector("_Position", new Vector4(0.3f,0,270,0));
        
        Debug.Log(bearMaterial.GetVector("_Position"));

        if (PlayerPrefs.HasKey("paintBear"))
        {
            paintBear = PlayerPrefs.GetFloat("paintBear");

        }
        else
        {
            PlayerPrefs.SetFloat("paintBear", 0);
        }

        if (PlayerPrefs.HasKey("collectedMoneyCount"))
        {
            collectedMoneyCount = PlayerPrefs.GetInt("collectedMoneyCount");

        }
        else
        {
            PlayerPrefs.SetInt("collectedMoneyCount", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        collectedMoneyText.text = "YOUR MONEY " + collectedMoneyCount + " /140$";

        collectedMoneyCount = Mathf.Clamp(collectedMoneyCount,0, 140);

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        

        if (startPaint)
        {

            StartCoroutine(PaintBear());
        }
        Debug.Log(paintBear);
        bearMaterial.SetFloat("_Radius", paintBear);
        stick.transform.position = new Vector3(stick.transform.position.x, paintBear - 0.1f, stick.transform.position.z);
    }

 

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collected")
        {
            if (collectedMoneyCount < 140f)
            {
                collectedMoneyCount += ((int)other.gameObject.GetComponent<CollectCoins>().myMoney);
                PlayerPrefs.SetInt("collectedMoneyCount", collectedMoneyCount);
            }
         
          
          
          
            startPaint = true;
        }
    }

    IEnumerator PaintBear()
    {
       
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().movementSpeed == 0)
        {

            yield return new WaitForSeconds(2);
            

            bearMaterial.SetFloat("_Radius", paintBear);

            if (paintBear <= collectedMoneyCount / 20 && paintBear <=140f)
            {
                paintBear += Time.deltaTime * 2;
                PlayerPrefs.SetFloat("paintBear", paintBear);
               

            }
            else
            {
                yield return new WaitForSeconds(1);
                if (collectedMoneyCount >= 140)
                {
                    StartCoroutine(PutBearToPodium());
                }
     
            }
           
        }

    }

    IEnumerator PutBearToPodium()
    {
        bear.transform.position = Vector3.MoveTowards(bear.transform.position, podium.transform.position, 15 * Time.deltaTime);
      
        bearMaterial.SetVector("_Position", bear.transform.position);

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().target = podium;

        yield return new WaitForSeconds(1.5f);

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().canRotateAround = true;


    }
}
