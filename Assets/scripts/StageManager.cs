using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// GameManager에서 관리하는 것이 좋지 않을까 생각했으나
/// 씬을 변경해도 사라지면 안되기 때문에 
/// 씬(Stage)을 관리하는 새로운 매니저를 만든다
/// </summary>
public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    // 스테이지의 이름을 저장한 배열
    public string[] scenes = { "StartScene", "SelectScene", "IJ_CardGame", "SG_Stage", "YS_MainScene", "SuccessScene", "EndScene" };

    // Scene을 클릭할 Image를 만든다
    public GameObject[] stages; // 0~2:노멀스테이지, 3:히든스테이지
    public StageInfo stage2_back;
    public StageInfo stage3_back;

    // 각 stage의 clear 정보
    const int stageCount = 3;       // 3개의 노멀 스테이지가 존재
    public bool[] isStageClear;
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
        isStageClear = new bool[stageCount];
        for (int i = 0; i < stageCount; i++)
        {
            isStageClear[i] = false;
        }
        isHiddenStageOn = false;

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
        // Debug.Log("호출"); // 디버그 확인용

        // bool변수값을 비교하여, 씬을 Active상태로 만든다
        for (int i = 0; i <= stageCount; i++)
        {
            if (i < stageCount)
            {
                if (isStageClear[i])
                {                    
                    // 확인이 필요하다
                    StageInfo childStageInfo = stages[i].GetComponentInChildren<StageInfo>();
                    if (childStageInfo == stage2_back || childStageInfo == stage3_back)
                    {
                        childStageInfo.OpenLock(); // 자물쇠 여는 애니메이션을 먼저 진행
                    }
                    //
                    stages[i].SetActive(true);  // 앞면을 활성화
                }
            }
            else
            {
                if (isHiddenStageOn)
                {

                    stages[i].SetActive(true);
                }
            }
        }
    }
    // stage를 클리어하면, 해당 stage의 isStageClear값을 true로 바꾼다
    public void ClearStage(int index)
    {
        // 해당 씬의 인덱스를 가져오거나 변수로 전달받는다
        // RetryButton의 GoToNextStage에서 호출하는 것이 자연스럽다
        // 그러면 변수로 전달받는것이 좋다

        // 노멀스테이지를 모두 클리어하지 않은 경우
        if (!isStageClear[index])
        {
            isStageClear[index] = true;
            // 노멀스테이지를 모두 클리어한 경우
            if (index == stageCount)
            {
                isHiddenStageOn = true;
                return;
            }
            else
            {
                return;
            }
        }
        // 클리어한 경우 이미 true이다
        return;
    }
    // 버튼을 클릭했을 때
    public void GoToStage(int index)
    {
        // 클릭한 Image의 스테이지로 이동한다
        // 맵의 이름을 Stage_1 이런식으로 바꾸는게 좋지 않을까 생각함
        switch (index)
        {
            case 1:
                SceneManager.LoadScene("IJ_CardGame");
                break;
            case 2:
                SceneManager.LoadScene("SG_Stage");
                break;
            case 3:
                SceneManager.LoadScene("YS_MainScene");
                break;
            case 4:
                SceneManager.LoadScene("SuccessScene");
                break;
            default:
                break;
        }
    }
}
