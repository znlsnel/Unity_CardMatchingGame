using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1 : MonoBehaviour
{
    public int stageId;
    public Transform front;

    void Start()
    {
        front = transform.Find("Front");
    }
    // Ŭ���ϸ� ����Ǵ� �Լ�
    public void GoToStage()
    {
        Object tmpScene = StageManager.Instance.stageList[stageId];
        SceneManager.LoadScene(tmpScene.name);
    }
}
