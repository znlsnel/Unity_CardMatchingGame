using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    /// Scene을 인스펙터창에 연결하는 방법은 다음과 같다
    // Object형으로 선언하면 Scene을 에디터로 연결할 수 있지만
    // Scene형으로 선언하면 에디터로 연결할 수 없다
    /// Scene은 저장하면 다른 씬이 로드되더라도 참조가 보전된다
    [SerializeField] Object startScene;
    [SerializeField] Object selectScene;
    public List<Object> stageList;  // 실제로 씬을 저장할 리스트
    // 각 stage의 clear 정보
    const int stageCount = 3;       // 3개의 노멀 스테이지가 존재
    public bool[] isNormalStageClear;     // 이건 스테이지 클리어를 한 표시이다
    public bool[] isStageOpened;    // StageLock은 이 변수를 기준으로 하는 것이 더 알아보기 쉽다
    public bool isHiddenStageOn;    // 히든 스테이지
    public bool[] isUnLocked;         // 2,3의 자물쇠가 풀렸는가?


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        // 다른 씬을 열더라도, 스테이지 클리어 정보는 지워지면 안된다
        DontDestroyOnLoad(gameObject);
        /// 하지만, 참조로 가지고 있는 stages의 게임오브젝트들은 삭제된다
    }
    void Start()
    {
        // 멤버변수 초기화
        isNormalStageClear = new bool[stageCount];
        for (int i = 0; i < isNormalStageClear.Length; i++)
        {
            isNormalStageClear[i] = false;
        }
        isStageOpened = new bool[stageCount + 1];
        for (int i = 0; i < isStageOpened.Length; i++)
        {
            if (i == 0)
            {
                isStageOpened[i] = true;
            }
            else
            {
                isStageOpened[i] = false;
            }
        }
        isUnLocked = new bool[stageCount + 1];
        for (int i = 0; i < isUnLocked.Length; i++)
        {
            // 스테이지1과 히든스테이지의 경우 StageLock의 stageId와 인덱스를 맞추기 위해 추가
            // StageLock의 UnLock이 실행된 후에 true로 갱신되어, 애니메이션의 중복 실행을 막는다
            isUnLocked[i] = false;  
        }
        isHiddenStageOn = false;
    }
    // stage를 클리어하면, 해당 stage의 isStageClear값을 true로 바꾼다


    public void ClearStage(int index)
    {
            isNormalStageClear[index] = true;

            if (index == stageCount)
            {
                isHiddenStageOn = true;
                return;
            }
            else
            {
                isStageOpened[index + 1] = true;
                return;
            }
    }
}
