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
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void BackToTitle()
    {
        // 에디터로 연결하지 않고 만들어보자
        // StageManager의 변수는 private이라 접근할 수 없다
        // 그렇다면 빌드를 이용한다
        SceneManager.LoadScene(0);  // buildIndex가 0: StartScene
    }
    public void BackToSelectScene()
    {
        SceneManager.LoadScene(1);  // buildIndex가 1: SelectScene
    }
}
