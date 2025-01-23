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
    // �ɼ�UI ����
    public void OpenOptionUI()
    {
        Time.timeScale = 0.0f;
        optionUI.SetActive(true);
    }

    // Ŭ���ϸ� �ɼ� UI �ݰ�, �̾ ���� ����
    public void CloseOptionUI()
    {
        Time.timeScale = 1.0f;
        optionUI.SetActive(false);
    }
}
