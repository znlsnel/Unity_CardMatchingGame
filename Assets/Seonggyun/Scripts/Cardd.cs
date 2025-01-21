using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardd : MonoBehaviour
{
    public int idx = 0;    // Board에서 대입할 인덱스

    public GameObject front;    // Front
    public GameObject back;     // Front

    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;

    public SpriteRenderer frontImage;   // Front에 들어있는 SpriteRenderer

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }
    public void Setting(int number)
    {
        idx = number;
        // 불러온 카드를 front에 대입한다
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }
    public void OpenCard()
    {
        if (GameManager.Instance.secondCard != null) return;

        audioSource.PlayOneShot(clip);  // AudioClip끼리 겹치지 않는다
        anim.SetBool("isOpen", true);   // CardFlip 애니메이션으로 바꾼다
        front.SetActive(true);
        back.SetActive(false);

        // firstCard가 비었다면 
        if (GameManager.Instance.firstCard == null)
        {
            // firstCard에 내 정보를 넘겨준다
            GameManager.Instance.firstCard = this;
        }
        // firstCard가 비어있지 않다면 
        else
        {
            // secondCard에 내 정보를 넘겨준다
            GameManager.Instance.secondCard = this;

            // Matched함수를 호출한다
            GameManager.Instance.Matched();
        }
    }
    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);  // 1초 후 삭제
    }
    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1.0f);
    }
    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);  // CardIdle 애니메이션으로 바꾼다
        front.SetActive(false);
        back.SetActive(true);
    }
}
