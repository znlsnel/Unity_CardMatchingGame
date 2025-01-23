using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject producer;


    [NonSerialized] public Card firstCard;
    [NonSerialized] public Card secondCard;

    public Text timeTxt;

    public GameObject endTxt;

    AudioSource audioSource;
    public AudioClip matchAudio;
    public AudioClip successAudio;
    public AudioClip failureAudio;

    public int cardCount = 0;
    float time = 0.0f;

    public bool isClear = false;
    public bool isStart = false;
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
        isStart = false;
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        timeTxt.text = time.ToString("N2");

    }

    public void StartTimer()
    {
        isStart = true;
    }

    void Update()
    {
        if (isClear || isStart == false)
            return;

        if (time < 30.0f)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");

            if (time >= 30.0f)
                audioSource.PlayOneShot(failureAudio);
        }
        else
        {
            endTxt.SetActive(true);
            AudioManager.Instance.StopAudio();
            Time.timeScale = 0.0f;
        }
    }
    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(matchAudio);

            firstCard.DestroyCard();
            secondCard.DestroyCard();

            cardCount -= 2;
            if (cardCount == 14)
            {
                isClear = true;
                AudioManager.Instance.StopAudio();
                audioSource.PlayOneShot(successAudio);

                int index = SceneManager.GetActiveScene().buildIndex;
                StageManager.Instance.ClearStage(index - 2);

                Invoke("ShowProducerInvoke", 1.0f);
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        firstCard = null;
        secondCard = null;
    }

    public void ShowProducerInvoke()
    {
        producer.SetActive(true);
    }
}
