using UnityEngine;

public class Card_I : MonoBehaviour
{
    public int index = 0;
    public SpriteRenderer frontImage;
    
    public Animator anim;
    public BoxCollider2D col;
    
    public void Start()
    {
        col.GetComponent<BoxCollider2D>();
        anim.SetBool("isOpen", true);
        Invoke("CloseCard", 1.0f);

    }
    public void OpenCard()
    {
            anim.SetBool("isOpen", true);
        
        if (GameManager_I.Instance.firstCard == null)
        {
            GameManager_I.Instance.firstCard = this;
        }
        else
        {
            GameManager_I.Instance.secondCard = this;
            GameManager_I.Instance.isMatched();
        }
    }

    public void DestroyCard()
    {
        Invoke("DestoryCardInvoke", 1.0f);
    }
    void DestoryCardInvoke()
    {
        Destroy(gameObject);
    }
    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1.0f);
    }
    void CloseCardInvoke()
    {
        
        anim.SetBool("isOpen", false);
        
    }



    public void Setting(int number)
    {
        index = number;
        Sprite loadedSprite = Resources.Load<Sprite>($"Ikjun{index}");
        if (loadedSprite != null)
        {
            frontImage.sprite = loadedSprite;
            
        }
        else
        {
            Debug.LogError($"Ikjun{index} 스프라이트를 찾을 수 없습니다.");
        }
    }
}
