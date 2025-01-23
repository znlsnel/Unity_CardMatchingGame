using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenStage : MonoBehaviour
{
    public int stageId;
    public Transform front;

    // Start is called before the first frame update
    void Start()
    {
        front = transform.Find("Front");
        OpenHidden();
    }
    public void OpenHidden()
    {
        if (StageManager.Instance.isStageOpened[stageId])
        {
            front.gameObject.SetActive(true);
        }
    }

    // 클릭하면 실행되는 함수
    public void GoToStage()
    {
        Object tmpScene = StageManager.Instance.stageList[stageId];
        SceneManager.LoadScene(tmpScene.name);
    }
}
