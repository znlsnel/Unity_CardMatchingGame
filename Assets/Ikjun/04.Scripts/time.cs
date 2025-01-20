using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour
{
    public Text timeTxt;
    float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;
        timeTxt.text = timer.ToString("N2");
    }
}
