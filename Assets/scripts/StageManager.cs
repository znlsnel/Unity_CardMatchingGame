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
    [SerializeField] Object successScene;
    public List<Object> stageList;  // ������ ���� ������ ����Ʈ
    // �� stage�� clear ����
    const int stageCount = 3;       // 3���� ��� ���������� ����
    public bool[] isNormalStageClear;     // �̰� �������� Ŭ��� �� ǥ���̴�
    public bool[] isStageOpened;    // StageLock�� �� ������ �������� �ϴ� ���� �� �˾ƺ��� ����
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
        isHiddenStageOn = false;

        /// �Ʒ��� ������ �ʿ��ұ�? �ٸ������� StageManager�� �����Ͽ� ������ �ٲܰ��̹Ƿ� �ʿ����� ������
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
        // bool�������� ���Ͽ�, 1����, ���� Active���·� �����
        for (int i = 0; i <= stageCount; i++)
        {
            // i�� 0�̸� stage1�� �˾ƺ��� �ִ°��̴�
            // stage1�� ������ ���� ������ i�� 0�϶��� �������� �ʴ´�
            if ((i > 0) && (i < stageCount))
            {
                // i�� 1�̸� isStageClear�迭������ stage2�� Ŭ���� ������ ��� �ִ�
                // stageBack����Ʈ�� 0�� �ε������� stage2�� �޸��� �������Ƿ�
                // isStageClear�迭�� i�� �ε����� stageBack����Ʈ�� i-1�� �ε����� ���� stage�� ���ϴ� ���̴� 
                if (isNormalStageClear[i])
                {
                }
                else
                {
                    return;
                }
            }
            else // i == 3: ���� ��������
            {
                if (isHiddenStageOn)
                {
                    //stageFront[i].SetActive(true);
                }
            }
        }
    }
    // stage�� Ŭ�����ϸ�, �ش� stage�� isStageClear���� true�� �ٲ۴�
    public void ClearStage(int index)
    {
        // Matched�� ȣ��ǰ� �ִ� Scene�� ������ �����´�
        // Ŭ������ �Ŀ� ���޵ǹǷ� bool���� �׳� true�� �ٲٸ� �ȴ�

        // ��ֽ��������� ��� Ŭ�������� ���� ���
        if (!isNormalStageClear[index])
        {
            isNormalStageClear[index] = true;
            // ��ֽ��������� ��� Ŭ������ ���
            if (index == stageCount)
            {
                isHiddenStageOn = true;
                return;
            }
            else
            {
                // stage1�� Ŭ�����ߴٸ� 2�� open�ؾ��Ѵ�
                isStageOpened[index + 1] = true;
                return;
            }
        }
        // Ŭ������ ��� �̹� true�̴�
        return;
    }
}
