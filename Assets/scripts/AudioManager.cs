using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;
	public AudioSource audioSource;
	public AudioClip clip;

	float time = 0.0f;
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

	private void Update()
	{
		time += Time.deltaTime;

		if (time >= 10.0f)
		{
			UpPitch();
			time = 0.0f;
		}
	}

	public void UpPitch()
	{
		audioSource.pitch += 0.1f;
	}

	public void StopAudio()
	{
		audioSource.Stop();
	}
	// Ãß°¡
	public void SetMusicVolume(float volume)
	{
		audioSource.volume = volume;
	}
}