using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// GameManager에서 관리하는 것이 좋지 않을까 생각했으나
/// 씬을 변경해도 사라지면 안되기 때문에 
/// 씬(Stage)을 관리하는 새로운 매니저를 만든다
/// </summary>
public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    // 씬의 정보와 스테이지 클리어 여부를 GameManager에서 관리
    // 스테이지의 이름을 저장한 배열
    public string[] scenes = { "StartScene", "Stage1", "Stage2", "Stage3", "EndScene" };

    // 각 stage의 정보가 있어야 한다
    // bool 변수가 필요하다
    const int stageCount = 3;   // 3개의 노멀 스테이지가 존재
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
    }
    void Start()
    {
        // 멤버변수 초기화
        bool[] isStageClear = new bool[stageCount];
        for (int i = 0; i < stageCount; i++)
        {
            isStageClear[i] = false;
        }
        isHiddenStageOn = false;
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
                // 연결된 UI? 를 Active한다
                // UI 만든다
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
}
