using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    // 다음 씬으로 넘어간다(시작화면에서 넘어갈 때, 스테이지 클리어할 때)
    public void GoToNextStage()
    {
        // 열려있는 씬의 다음 씬
        Scene curScene = SceneManager.GetActiveScene();
        string sceneName = curScene.name;

        // 배열에서 현재 열려있는 씬의 인덱스를 가져온다 
        int index = Array.IndexOf(StageManager.Instance.scenes, sceneName);
        if ((index >= 0) && index < StageManager.Instance.scenes.Length - 1)
        {
            // 현재 씬은 clear했으니 true로 바꾼다
            StageManager.Instance.ClearStage(index);
            // 다음 씬으로 넘어간다
            index++;
        }
        else
        {
            // 다시 메인으로 돌아간다
            index = 0;
        }
        SceneManager.LoadScene(StageManager.Instance.scenes[index]);
    }
    public void Retry()
    {
        // 열려있는 씬을 다시 실행한다
        Scene curScene = SceneManager.GetActiveScene();
        string sceneName = curScene.name;
        SceneManager.LoadScene(sceneName);
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene(StageManager.Instance.scenes[0]);
    }
}
