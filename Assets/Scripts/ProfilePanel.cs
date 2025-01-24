using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePanel : MonoBehaviour
{
	[SerializeField] GameObject selectStageBtn;
	[SerializeField] GameObject replayBtn;
	[SerializeField] Text introduceText;
	[SerializeField] List<AudioClip> _audioClips;

	string itdText;
	AudioSource audioSource;
	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		itdText = introduceText.text;
		introduceText.text = "";

		selectStageBtn.SetActive(false);
		replayBtn.SetActive(false); 
	}

	public void AE_TypingText()
	{
		StartCoroutine(TypingText());
	}

	IEnumerator TypingText()
	{
		int i = 0;
		while (i < itdText.Length) 
		{
			introduceText.text += itdText[i++];
			audioSource.clip = _audioClips[Random.Range(0, _audioClips.Count)];
			audioSource.Play();
			yield return new WaitForSeconds(0.1f); 
		}

		selectStageBtn.SetActive(true);
		replayBtn.SetActive(true);
	}
}
