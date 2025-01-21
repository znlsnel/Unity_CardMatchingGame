using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject producer; // 해당 스테이지 제작자의 정보(이름 Text, Image, 설명 Text)

    // 카드 2개의 정보를 가지고 있어야 한다
    public Cardd firstCard;
    public Cardd secondCard;

    public Text timeTxt;
    public GameObject clearText;    // 클리어(성공메세지)
    public GameObject endTxt;       // 시간초과(실패메세지)

    AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;      // 게임 씬에 남아있는 카드 개수
    float time = 0.0f;     

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1.0f;  // 재실행
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (time < 30.0f)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");
        }
        else
        {
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;  // 정지
        }
    }
    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            // 삭제
            // 이때 여기서 바로 Destroy를 호출하지 않고, Card 클래스에서 만든 삭제함수를 사용한다
            // 비활성화한 카드는 cardPool에 추가
            audioSource.PlayOneShot(clip); 
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                // StageClear 메세지 호출
                clearText.SetActive(true);

                // 각각 스테이지를 하나씩 만들고, 스테이지를 만든 제작자의 정보를 보여주는 식으로 하면 좋을 듯
                Invoke("ShowProducerInvoke", 1.0f); // 1초 후에 제작자 정보 보여주기
                // 하지만 현재 진입을 안한다

                // endTxt의 위치를 조금 바꾸자
                //endTxt.SetActive(true);
                Time.timeScale = 0.0f;  // 정지
            }
        }
        else
        {
            // 다시 뒤집어라
            // 이때 여기서 바로 활성화, 비활성화하지 않고, Card 클래스에서 만든 뒤집기함수를 사용한다
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        // 삭제가 되었든 뒤집었든 간에 firstCard, secondCard는 비워줘야한다
        firstCard = null;
        secondCard = null;
    }

    // 스테이지 제작자 정보 보여주기
    public void ShowProducerInvoke()
    {
        // 진입을 안한다?
        clearText.SetActive(false);
        producer.SetActive(true);
    }
}
