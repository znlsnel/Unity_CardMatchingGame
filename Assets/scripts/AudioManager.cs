using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;
	public AudioSource audioSource;
	public AudioClip clip;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		 
	}
	
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.pitch = 1.0f;

		audioSource.clip = this.clip;
		audioSource.Play();
	}

	public void UpPitch()
	{
		audioSource.pitch += 0.1f;
	}

}
