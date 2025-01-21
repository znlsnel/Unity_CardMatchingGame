using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 같은것이 존재한다면, 삭제한다
            Destroy(gameObject);
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = this.clip;
        audioSource.Play();
    }
}
