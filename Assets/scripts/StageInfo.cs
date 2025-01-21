using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfo : MonoBehaviour
{
    public int stageId;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // StageManager�� bool�� true�� �Ǹ� ȣ���Ѵ�. 1������ �ִϸ��̼��� �����ϰ�
    public void OpenLock()
    {
        StartCoroutine(OpenLockCoroutine());
    }
    private IEnumerator OpenLockCoroutine()
    {
        // ���� �ִϸ��̼� ���¸� �����´�
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        // ���� �ִϸ��̼� Ŭ�� ���¸� �����´�(�ڹ��� Unlock 1�����̴�)
        AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);

        if (clipInfo.Length > 0)
        {
            // ù ��° Ŭ���� ���̸� �����´�
            float clipLength = clipInfo[0].clip.length;
            // �ִϸ��̼� ����
            anim.SetTrigger("Unlock");
            // �ִϸ��̼� Ŭ�� ���̸�ŭ ���
            yield return new WaitForSeconds(clipLength);
            Debug.Log("�ִϸ��̼� ��� �Ϸ�. ���� �۾� ����");
        }
    }
}
