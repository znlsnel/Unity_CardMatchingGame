using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnim : MonoBehaviour
{
    
    public GameObject eachCard; // 카드 오브젝트
    AudioSource audioSource;
    public AudioClip audioClip;

    public void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    // 버튼 클릭 시 호출되는 메서드
    public void OnClickCard()
    {
        eachCard.GetComponent<BigClickAnim>().isDowntrigger();
        audioSource.PlayOneShot(audioClip);

    }

    
}
