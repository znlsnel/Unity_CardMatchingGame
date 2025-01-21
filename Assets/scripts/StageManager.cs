using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// GameManager���� �����ϴ� ���� ���� ������ ����������
/// ���� �����ص� ������� �ȵǱ� ������ 
/// ��(Stage)�� �����ϴ� ���ο� �Ŵ����� �����
/// </summary>
public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    // ���� ������ �������� Ŭ���� ���θ� GameManager���� ����
    // ���������� �̸��� ������ �迭
    public string[] scenes = { "StartScene", "Stage1", "Stage2", "Stage3", "EndScene" };

    // �� stage�� ������ �־�� �Ѵ�
    // bool ������ �ʿ��ϴ�
    const int stageCount = 3;   // 3���� ��� ���������� ����
    public bool[] isStageClear;
    public bool isHiddenStageOn;    // ���� ��������

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        // �ٸ� ���� ������, �������� Ŭ���� ������ �������� �ȵȴ�
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        // ������� �ʱ�ȭ
        bool[] isStageClear = new bool[stageCount];
        for (int i = 0; i < stageCount; i++)
        {
            isStageClear[i] = false;
        }
        isHiddenStageOn = false;
    }
    // stage�� Ŭ�����ϸ�, �ش� stage�� isStageClear���� true�� �ٲ۴�
    public void ClearStage(int index)
    {
        // �ش� ���� �ε����� �������ų� ������ ���޹޴´�
        // RetryButton�� GoToNextStage���� ȣ���ϴ� ���� �ڿ�������
        // �׷��� ������ ���޹޴°��� ����

        // ��ֽ��������� ��� Ŭ�������� ���� ���
        if (!isStageClear[index])
        {
            isStageClear[index] = true;
            // ��ֽ��������� ��� Ŭ������ ���
            if (index == stageCount)
            {
                isHiddenStageOn = true;
                // ����� UI? �� Active�Ѵ�
                // UI �����
                return;
            }
            else
            {
                return;
            }
        }
        // Ŭ������ ��� �̹� true�̴�
        return; 
    }
}
