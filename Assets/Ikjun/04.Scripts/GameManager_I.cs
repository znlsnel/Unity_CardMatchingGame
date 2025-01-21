using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_I : MonoBehaviour
{
    public static GameManager_I Instance;
    public Text timeTxt;
    private float timer = 0.0f;

    public Card_I firstCard;
    public Card_I secondCard;
    public GameObject endTxt;

    public int cardCount = 0;
    

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (Time.timeScale == 1.0f) // Time.timeScale이 1일 때만 타이머가 작동
        {
            timer += Time.deltaTime;
            timeTxt.text = timer.ToString("N2");
        }
    }

    // 카드를 매칭 확인

    public void isMatched()
    {
        if (firstCard.index == secondCard.index)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            Debug.Log(cardCount);
            if (cardCount == 0)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
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

    // 카드가 클릭될 때 호출될 메서드
    public void CardRevealed(Card_I card)
    {
        // 첫 번째 카드 클릭 시
        if (firstCard == null)
        {
            firstCard = card;
        }
        // 두 번째 카드 클릭 시
        else if (secondCard == null && card != firstCard)
        {
            secondCard = card;
            isMatched();  // 두 카드 비교 후 매칭 여부 처리
        }
    }
}
