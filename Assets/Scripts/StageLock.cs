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

    public void UnLock()
    {
        if (!StageManager.Instance.isUnLocked[stageId])
        {
            if (StageManager.Instance.isStageOpened[stageId])
            {
                anim.SetBool("isOpened", true);
            }
        }
        else // Select������ ���ƿö�, �ڹ��谡 ������� �ʴ� ��쿡 ���� ��Ȱ��ȭ
        {
            back.gameObject.SetActive(false);
            front.gameObject.SetActive(true);
        }
    }

    // �ִϸ��̼��� ������ �̺�Ʈ ȣ��
    public void OnAnimationComplete()
    {
        back.gameObject.SetActive(false);
        front.gameObject.SetActive(true);
        // �ִϸ��̼��� ��������, true�� �ٲپ�, �ִϸ��̼��� �ߺ� ������ ���´�
        StageManager.Instance.isUnLocked[stageId] = true;
    }

    // Ŭ���ϸ� ����Ǵ� �Լ�
    public void GoToStage()
    {
        Object tmpScene = StageManager.Instance.stageList[stageId];
        SceneManager.LoadScene(tmpScene.name);
    }

}
