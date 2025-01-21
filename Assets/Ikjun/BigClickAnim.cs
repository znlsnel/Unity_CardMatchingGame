using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigClickAnim : MonoBehaviour
{
    public Animator anim;
    public GameObject canvas;
    public static BigClickAnim bigClick;
    public AudioClip audioClip;
    AudioSource audioSource;

    public void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

        
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }


    public void isDowntrigger()
    {
        anim.SetTrigger("isDown");
        audioSource.PlayOneShot(audioClip);
    }

    public void OnClick()
    {
        anim.SetTrigger("isUp");
        audioSource.PlayOneShot(audioClip);

    }

   
}