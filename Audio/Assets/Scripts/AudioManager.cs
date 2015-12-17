using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	public static AudioManager instance = null;
	public GameObject audioItem;
	
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
	public void Play(AudioClip clip) 
	{
		GameObject go = (GameObject)Instantiate (audioItem);
		AudioSource src = go.GetComponent<AudioSource> ();
		src.clip = clip;

		src.Play ();
		Destroy (go, clip.length);
	}
}