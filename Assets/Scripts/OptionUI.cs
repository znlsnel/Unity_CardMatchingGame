using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public GameObject optionUI;    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // 옵션UI 열기
    public void OpenOptionUI()
    {
        Time.timeScale = 0.0f;
        optionUI.SetActive(true);
    }

    // 클릭하면 옵션 UI 닫고, 이어서 게임 진행
    public void CloseOptionUI()
    {
        Time.timeScale = 1.0f;
        optionUI.SetActive(false);
    }
}
