using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        // 열려있는 씬을 다시 실행한다
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void BackToTitle()
    {

        SceneManager.LoadScene(StageManager.Instance.scenes[0]);
    }
    // Stage선택창으로 돌아가는 UI를 클릭할 때 호출되는 메서드
    public void BackToSelectScene()
    {
        SceneManager.LoadScene(StageManager.Instance.scenes[1]);
    }
}
