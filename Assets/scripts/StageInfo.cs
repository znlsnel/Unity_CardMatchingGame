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

    // StageManager가 bool이 true가 되면 호출한다. 1초정도 애니메이션을 진행하고
    public void OpenLock()
    {
        StartCoroutine(OpenLockCoroutine());
    }
    private IEnumerator OpenLockCoroutine()
    {
        // 현재 애니메이션 상태를 가져온다
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        // 현재 애니메이션 클립 상태를 가져온다(자물쇠 Unlock 1개뿐이다)
        AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);

        if (clipInfo.Length > 0)
        {
            // 첫 번째 클립의 길이를 가져온다
            float clipLength = clipInfo[0].clip.length;
            // 애니메이션 실행
            anim.SetTrigger("Unlock");
            // 애니메이션 클립 길이만큼 대기
            yield return new WaitForSeconds(clipLength);
            Debug.Log("애니메이션 재생 완료. 다음 작업 진행");
        }
    }
}
