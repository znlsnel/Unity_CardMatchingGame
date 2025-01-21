using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardd : MonoBehaviour
{
    public int idx = 0;    // Board���� ������ �ε���

    public GameObject front;    // Front
    public GameObject back;     // Front

    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;

    public SpriteRenderer frontImage;   // Front�� ����ִ� SpriteRenderer

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
        // �ҷ��� ī�带 front�� �����Ѵ�
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }
    public void OpenCard()
    {
        if (GameManager.Instance.secondCard != null) return;

        audioSource.PlayOneShot(clip);  // AudioClip���� ��ġ�� �ʴ´�
        anim.SetBool("isOpen", true);   // CardFlip �ִϸ��̼����� �ٲ۴�
        front.SetActive(true);
        back.SetActive(false);

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
        front.SetActive(false);
        back.SetActive(true);
    }
}
