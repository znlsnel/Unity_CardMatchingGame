using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject producer; // �ش� �������� �������� ����(�̸� Text, Image, ���� Text)

    // ī�� 2���� ������ ������ �־�� �Ѵ�
    [NonSerialized] public Card firstCard;
    [NonSerialized] public Card secondCard;

    public Text timeTxt;

    public GameObject endTxt;       // �ð��ʰ�(���и޼���)

    AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;      // ���� ���� �����ִ� ī�� ����
    float time = 0.0f;

        bool isClear = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
                isClear = false;
        Time.timeScale = 1.0f;  // �����
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
                if (isClear)
                        return;

        if (time < 30.0f)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");
        }
        else
        {
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;  // ����
        }
    }
    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            // ����
            // �̶� ���⼭ �ٷ� Destroy�� ȣ������ �ʰ�, Card Ŭ�������� ���� �����Լ��� ����Ѵ�
            // ��Ȱ��ȭ�� ī��� cardPool�� �߰�
            audioSource.PlayOneShot(clip);

            firstCard.DestroyCard();
            secondCard.DestroyCard();

            cardCount -= 2; 
            if (cardCount == 0)
            {
                 isClear = true;
		// StageClear �޼��� ȣ��


				// ���� ���������� �ϳ��� �����, ���������� ���� �������� ������ �����ִ� ������ �ϸ� ���� ��
		Invoke("ShowProducerInvoke", 1.0f); // 1�� �Ŀ� ������ ���� �����ֱ�
                // ������ ���� ������ ���Ѵ�

                // endTxt�� ��ġ�� ���� �ٲ���
                //endTxt.SetActive(true);

            }
        }
        else
        {
            // �ٽ� �������
            // �̶� ���⼭ �ٷ� Ȱ��ȭ, ��Ȱ��ȭ���� �ʰ�, Card Ŭ�������� ���� �������Լ��� ����Ѵ�
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        // ������ �Ǿ��� �������� ���� firstCard, secondCard�� �������Ѵ�
        firstCard = null;
        secondCard = null;
    }

    // �������� ������ ���� �����ֱ�
    public void ShowProducerInvoke()
    {
        // ������ ���Ѵ�?

        producer.SetActive(true);
    }
}
