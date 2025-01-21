using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    // ���������� �̸��� ������ �迭
    public string[] scenes = { "StartScene", "Stage1", "Stage2", "Stage3", "EndScene" };

    // ���� ������ �Ѿ��(����ȭ�鿡�� �Ѿ ��, �������� Ŭ������ ��)
    public void GoToNextStage()
    {
        // �����ִ� ���� ���� ���� ��
        Scene curScene = SceneManager.GetActiveScene();
        string sceneName = curScene.name;

        // �迭���� ���� �����ִ� ���� �ε����� �����´� 
        int index = Array.IndexOf(scenes, sceneName);
        if ((index >= 0) && index < scenes.Length - 1)
        {
            // ���� ������ �Ѿ��
            index++;
        }
        else
        {
            // �ٽ� �������� ���ư���
            index = 0;
        }
        SceneManager.LoadScene(scenes[index]);
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
        SceneManager.LoadScene(scenes[0]);
    }
}
