using UnityEngine;
using System.Collections;

public class SoundManagerScript : MonoBehaviour {

	public AudioClip gameOverAudioClip;
    public AudioClip scoredAudioClip;
    public AudioClip coinAudioClip;

	public static AudioSource gameOverAudioSource;
    public static AudioSource scoredAudioSource;
    public static AudioSource coinAudioSource;

    AudioSource AddAudio(AudioClip clip, bool playOnAwake, bool loop, float  volume)
	{
		AudioSource audioSource = gameObject.AddComponent<AudioSource> ();
		audioSource.clip = clip;
		audioSource.playOnAwake = playOnAwake;
		audioSource.loop = loop;
		audioSource.volume = volume;
		return audioSource;
	}

	void Start () 
	{
		DontDestroyOnLoad (gameObject);
		gameOverAudioSource = AddAudio (gameOverAudioClip,false, false, 1.0f);
        scoredAudioSource = AddAudio(scoredAudioClip, false, false, .7f);
        coinAudioSource = AddAudio(coinAudioClip, false, false, .4f);
    }	
}
