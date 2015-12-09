using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	public static AudioManager instance = null;
	public GameObject audioItem;

	public AudioMixerGroup voiceMixer = null;
	public AudioMixerGroup sfxMixer = null;
	public AudioMixerGroup musicMixer = null;
	
	// Use this for initialization
	void Awake() 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);
	}
	

	// Update is called once per frame
	public void PlayVoice(AudioClip clip) 
	{
		GameObject go = Instantiate (audioItem);
		AudioSource src = go.GetComponent<AudioSource> ();
		src.outputAudioMixerGroup = voiceMixer;
		src.clip = clip;
		src.Play ();
		Destroy (go, clip.length);
	}

	// Update is called once per frame
	public void PlaySound(AudioClip clip) 
	{
		GameObject go = Instantiate (audioItem);
		AudioSource src = go.GetComponent<AudioSource> ();
		src.outputAudioMixerGroup = sfxMixer;
		src.clip = clip;
		src.pitch = Random.Range (0.95f, 1.05f);
		src.Play ();
		Destroy (go, clip.length);
	}

	public void PlayMusic(AudioClip clip) 
	{
		GameObject go = Instantiate (audioItem);
		AudioSource src = go.GetComponent<AudioSource> ();
		src.outputAudioMixerGroup = musicMixer;
		src.clip = clip;
		src.loop = true;
		src.Play ();
		//Destroy (go, clip.length);
	}
}