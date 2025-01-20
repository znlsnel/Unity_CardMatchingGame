using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
    public GameObject txt;
    public GameObject btn;


    public void OnclickBtn()
    {
        txt.SetActive(true);

        Destroy(btn);
    }
}
