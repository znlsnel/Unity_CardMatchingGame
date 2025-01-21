using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// GameManager���� �����ϴ� ���� ���� ������ ����������
/// ���� �����ص� ������� �ȵǱ� ������ 
/// ��(Stage)�� �����ϴ� ���ο� �Ŵ����� �����
/// </summary>
public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    // ���������� �̸��� ������ �迭
    public string[] scenes = { "StartScene", "SelectScene", "IJ_CardGame", "SG_Stage", "YS_MainScene", "SuccessScene", "EndScene" };

    // Scene�� Ŭ���� Image�� �����
    public GameObject[] stages; // 0~2:��ֽ�������, 3:���罺������
    public StageInfo stage2_back;
    public StageInfo stage3_back;

    // �� stage�� clear ����
    const int stageCount = 3;       // 3���� ��� ���������� ����
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
        /// ������, ������ ������ �ִ� stages�� ���ӿ�����Ʈ���� �����ȴ�
    }
    void Start()
    {
        // ������� �ʱ�ȭ
        isStageClear = new bool[stageCount];
        for (int i = 0; i < stageCount; i++)
        {
            isStageClear[i] = false;
        }
        isHiddenStageOn = false;

        // ������ ȣ��� �� ȣ���� �޼��带 �����Ѵ�
        // �������� �ʴ� ��, SelectScene�� �ε�� �� ��� �� �޼��带 ȣ���Ѵ�
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // SelectScene ���� �ε�� �� ȣ��
    // UI�� ��� ���� SelectScene���� ���ƿ��� �ؾ� �׽�Ʈ�� ������ �� �ϴ�
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ActiveSceneUI();
    }
    public void ActiveSceneUI()
    {
        // Debug.Log("ȣ��"); // ����� Ȯ�ο�

        // bool�������� ���Ͽ�, ���� Active���·� �����
        for (int i = 0; i <= stageCount; i++)
        {
            if (i < stageCount)
            {
                if (isStageClear[i])
                {                    
                    // Ȯ���� �ʿ��ϴ�
                    StageInfo childStageInfo = stages[i].GetComponentInChildren<StageInfo>();
                    if (childStageInfo == stage2_back || childStageInfo == stage3_back)
                    {
                        childStageInfo.OpenLock(); // �ڹ��� ���� �ִϸ��̼��� ���� ����
                    }
                    //
                    stages[i].SetActive(true);  // �ո��� Ȱ��ȭ
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
    // ��ư�� Ŭ������ ��
    public void GoToStage(int index)
    {
        // Ŭ���� Image�� ���������� �̵��Ѵ�
        // ���� �̸��� Stage_1 �̷������� �ٲٴ°� ���� ������ ������
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
