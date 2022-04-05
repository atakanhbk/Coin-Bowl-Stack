using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInformation : MonoBehaviour
{
    public static void LoadAllInformation()
    {
        GameInformation.TotalMoney = PlayerPrefs.GetInt("TOTALMONEY");
    }
}
