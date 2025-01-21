using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    // ���� ������ �Ѿ��(����ȭ�鿡�� �Ѿ ��, �������� Ŭ������ ��)
    public void GoToNextStage()
    {
        // �����ִ� ���� ���� ��
        Scene curScene = SceneManager.GetActiveScene();
        string sceneName = curScene.name;

        // �迭���� ���� �����ִ� ���� �ε����� �����´� 
        int index = Array.IndexOf(StageManager.Instance.scenes, sceneName);
        if ((index >= 0) && index < StageManager.Instance.scenes.Length - 1)
        {
            // ���� ���� clear������ true�� �ٲ۴�
            StageManager.Instance.ClearStage(index);
            // ���� ������ �Ѿ��
            index++;
        }
        else
        {
            // �ٽ� �������� ���ư���
            index = 0;
        }
        SceneManager.LoadScene(StageManager.Instance.scenes[index]);
    }
    public void Retry()
    {
        // �����ִ� ���� �ٽ� �����Ѵ�
        Scene curScene = SceneManager.GetActiveScene();
        string sceneName = curScene.name;
        SceneManager.LoadScene(sceneName);
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene(StageManager.Instance.scenes[0]);
    }
}
