using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [NonSerialized] public int idx = 0;    // Board���� ������ �ε���

    [SerializeField] GameObject front;    // Front
    [SerializeField] GameObject back;     // Front
    [SerializeField] string imagePath;
    [SerializeField] SpriteRenderer frontImage;   // Front�� ����ִ� SpriteRenderer

    AudioSource audioSource;
    Animator anim;

    public AudioClip audioclip;

        Vector3 cardPosition;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }
   
	private void Update() 
	{
                Vector3 dir = (cardPosition - gameObject.transform.position);
                if (dir.magnitude > 0.1f)
			gameObject.transform.position += dir.normalized * 10.0f * Time.deltaTime;
		
	} 

	public void Setting(int number, Vector2 pos)
        {
                cardPosition = pos;
                idx = number;
		frontImage.sprite = Resources.Load<Sprite>($"{imagePath}/image_{idx}");
        }

        public void StartCard()
        {
		anim.SetBool("isOpen", true);//시작시 모든카드 앞면
		Invoke("CloseCard", 1f);
	}

    public void OpenCard()
    {
        if (GameManager.Instance.secondCard != null) return;

        audioSource.PlayOneShot(audioclip);  // AudioClip���� ��ġ�� �ʴ´�
        anim.SetBool("isOpen", true);   // CardFlip �ִϸ��̼����� �ٲ۴�
        //front.SetActive(true);
        //back.SetActive(false);

        // firstCard�� ����ٸ� 
        if (GameManager.Instance.firstCard == null)
        {
            // firstCard�� �� ������ �Ѱ��ش�
            GameManager.Instance.firstCard = this;
        }
        // firstCard�� ������� �ʴٸ� 
        else
        {
            // secondCard�� �� ������ �Ѱ��ش�
            GameManager.Instance.secondCard = this;

            // Matched�Լ��� ȣ���Ѵ�
            GameManager.Instance.Matched();
        }
    }
    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);  // 1�� �� ����
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
        anim.SetBool("isOpen", false);  // CardIdle �ִϸ��̼����� �ٲ۴�
        //front.SetActive(false);
        //back.SetActive(true);
    }
}
