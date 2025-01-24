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

    public void UnLock()
    {
        if (!StageManager.Instance.isUnLocked[stageId])
        {
            if (StageManager.Instance.isStageOpened[stageId])
            {
                anim.SetBool("isOpened", true);
            }
        }
        else // Select씬으로 돌아올때, 자물쇠가 사라지지 않는 경우에 직접 비활성화
        {
            back.gameObject.SetActive(false);
            front.gameObject.SetActive(true);
        }
    }

    // 애니메이션이 끝나면 이벤트 호출
    public void OnAnimationComplete()
    {
        back.gameObject.SetActive(false);
        front.gameObject.SetActive(true);
        // 애니메이션이 끝났으면, true로 바꾸어, 애니메이션의 중복 실행을 막는다
        StageManager.Instance.isUnLocked[stageId] = true;
    }

    // 클릭하면 실행되는 함수
    public void GoToStage()
    {
        Object tmpScene = StageManager.Instance.stageList[stageId];
        SceneManager.LoadScene(tmpScene.name);
    }

}
