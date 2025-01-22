using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageLock : MonoBehaviour
{
    public int stageId;
    public Animator anim;   // 자신의 Animator
    public Transform front;
    public Transform back;

    void Start()
    {
        anim = GetComponent<Animator>();
        front = transform.Find("Front");
        back = transform.Find("Back");
        UnLock();
    }

    // StageManager가 bool이 true가 되면 호출한다. 1초정도 애니메이션을 진행하고
    public void UnLock()
    {
        // StageManager로부터 열렸는지 확인한다
        if (StageManager.Instance.isStageOpened[stageId])
        {
            anim.SetBool("isOpened", true);
            back.gameObject.SetActive(false);
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
