using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageLock : MonoBehaviour
{
    public int stageId;
    public Animator anim;   // �ڽ��� Animator
    public Transform front;
    public Transform back;

    void Start()
    {
        anim = GetComponent<Animator>();
        front = transform.Find("Front");
        back = transform.Find("Back");
        UnLock();
    }

    // StageManager�� bool�� true�� �Ǹ� ȣ���Ѵ�. 1������ �ִϸ��̼��� �����ϰ�
    public void UnLock()
    {
        // StageManager�κ��� ���ȴ��� Ȯ���Ѵ�
        if (StageManager.Instance.isStageOpened[stageId])
        {
            anim.SetBool("isOpened", true);
            back.gameObject.SetActive(false);
            front.gameObject.SetActive(true);
        }
    }
    // Ŭ���ϸ� ����Ǵ� �Լ�
    public void GoToStage()
    {
        Object tmpScene = StageManager.Instance.stageList[stageId];
        SceneManager.LoadScene(tmpScene.name);
    }

}
