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
        // �����ִ� ���� �ٽ� �����Ѵ�
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void BackToTitle()
    {
        //SceneManager.LoadScene(StageManager.Instance.startScene);
    }
    // Stage����â���� ���ư��� UI�� Ŭ���� �� ȣ��Ǵ� �޼���
    public void BackToSelectScene()
    {
        //SceneManager.LoadScene(StageManager.Instance.scenes[1]);
    }
}
