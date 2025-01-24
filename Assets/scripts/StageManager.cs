using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    /// Scene�� �ν�����â�� �����ϴ� ����� ������ ����
    // Object������ �����ϸ� Scene�� �����ͷ� ������ �� ������
    // Scene������ �����ϸ� �����ͷ� ������ �� ����
    /// Scene�� �����ϸ� �ٸ� ���� �ε�Ǵ��� ������ �����ȴ�
    [SerializeField] Object startScene;
    [SerializeField] Object selectScene;
    public List<Object> stageList;  // ������ ���� ������ ����Ʈ
    // �� stage�� clear ����
    const int stageCount = 3;       // 3���� ��� ���������� ����
    public bool[] isNormalStageClear;     // �̰� �������� Ŭ��� �� ǥ���̴�
    public bool[] isStageOpened;    // StageLock�� �� ������ �������� �ϴ� ���� �� �˾ƺ��� ����
    public bool isHiddenStageOn;    // ���� ��������
    public bool[] isUnLocked;         // 2,3�� �ڹ��谡 Ǯ�ȴ°�?


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
        isNormalStageClear = new bool[stageCount];
        for (int i = 0; i < isNormalStageClear.Length; i++)
        {
            isNormalStageClear[i] = false;
        }
        isStageOpened = new bool[stageCount + 1];
        for (int i = 0; i < isStageOpened.Length; i++)
        {
            if (i == 0)
            {
                isStageOpened[i] = true;
            }
            else
            {
                isStageOpened[i] = false;
            }
        }
        isUnLocked = new bool[stageCount + 1];
        for (int i = 0; i < isUnLocked.Length; i++)
        {
            // ��������1�� ���罺�������� ��� StageLock�� stageId�� �ε����� ���߱� ���� �߰�
            // StageLock�� UnLock�� ����� �Ŀ� true�� ���ŵǾ�, �ִϸ��̼��� �ߺ� ������ ���´�
            isUnLocked[i] = false;  
        }
        isHiddenStageOn = false;
    }
    // stage�� Ŭ�����ϸ�, �ش� stage�� isStageClear���� true�� �ٲ۴�


    public void ClearStage(int index)
    {
            isNormalStageClear[index] = true;

            if (index == stageCount)
            {
                isHiddenStageOn = true;
                return;
            }
            else
            {
                isStageOpened[index + 1] = true;
                return;
            }
    }
}
