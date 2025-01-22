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
    [SerializeField] Object successScene;
    public List<Object> stageList;  // 실제로 씬을 저장할 리스트
    // 각 stage의 clear 정보
    const int stageCount = 3;       // 3개의 노멀 스테이지가 존재
    public bool[] isNormalStageClear;     // 이건 스테이지 클리어를 한 표시이다
    public bool[] isStageOpened;    // StageLock은 이 변수를 기준으로 하는 것이 더 알아보기 쉽다
    public bool isHiddenStageOn;    // 히든 스테이지

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
        isHiddenStageOn = false;

        /// 아래의 내용은 필요할까? 다른곳에서 StageManager에 접근하여 변수만 바꿀것이므로 필요하지 않은듯
        // 다음에 호출될 때 호출할 메서드를 구독한다
        // 해제하지 않는 한, SelectScene이 로드될 때 계속 이 메서드를 호출한다
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // SelectScene 씬이 로드될 때 호출
    // UI를 띄운 다음 SelectScene으로 돌아오게 해야 테스트가 가능할 듯 하다
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ActiveSceneUI();
    }
    public void ActiveSceneUI()
    {
        // bool변수값을 비교하여, 1번만, 씬을 Active상태로 만든다
        for (int i = 0; i <= stageCount; i++)
        {
            // i가 0이면 stage1을 알아보고 있는것이다
            // stage1은 제약이 없기 때문에 i가 0일때는 진입하지 않는다
            if ((i > 0) && (i < stageCount))
            {
                // i가 1이면 isStageClear배열에서는 stage2의 클리어 정보를 담고 있다
                // stageBack리스트의 0번 인덱스에는 stage2의 뒷면이 들어가있으므로
                // isStageClear배열의 i번 인덱스와 stageBack리스트의 i-1번 인덱스가 같은 stage를 비교하는 셈이다 
                if (isNormalStageClear[i])
                {
                }
                else
                {
                    return;
                }
            }
            else // i == 3: 히든 스테이지
            {
                if (isHiddenStageOn)
                {
                    //stageFront[i].SetActive(true);
                }
            }
        }
    }
    // stage를 클리어하면, 해당 stage의 isStageClear값을 true로 바꾼다
    public void ClearStage(int index)
    {
        // Matched가 호출되고 있는 Scene의 정보를 가져온다
        // 클리어한 후에 전달되므로 bool값을 그냥 true로 바꾸면 된다

        // 노멀스테이지를 모두 클리어하지 않은 경우
        if (!isNormalStageClear[index])
        {
            isNormalStageClear[index] = true;
            // 노멀스테이지를 모두 클리어한 경우
            if (index == stageCount)
            {
                isHiddenStageOn = true;
                return;
            }
            else
            {
                // stage1을 클리어했다면 2를 open해야한다
                isStageOpened[index + 1] = true;
                return;
            }
        }
        // 클리어한 경우 이미 true이다
        return;
    }
}
