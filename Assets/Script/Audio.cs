using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*附加腳本時自動生成AudioSource元件*/
[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour {
	public AudioClip _sound;
	private AudioSource _audioSource;

	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void play_sound()
	{
		_audioSource.PlayOneShot(_sound);
	}
}
