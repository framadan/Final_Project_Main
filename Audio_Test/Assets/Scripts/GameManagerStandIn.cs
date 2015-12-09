//The game object prefab called "AudioManager" should be placed into the scene or instantiated on Awake

using UnityEngine;
using System.Collections;

public class GameManagerStandIn : MonoBehaviour 

{
	public GameObject audioManager = null;

	//Audio Clips should be declared in the script from which their respective play functions are called
	public AudioClip stageMusic = null;
	public AudioClip normalHit = null;
	public AudioClip critHit = null;

	void Awake () 
	{
		//This instantiates the audioManager prefab on Awake so that the music and sound effects can play. It must be in the scene before any audio will play.
		Instantiate (audioManager);
		//This calls the fuction contained in the AudioManager script that plays music. The stageMusic clip should be passed as an argument.
		AudioManager.instance.PlayMusic (stageMusic);
	}

	void Update ()
	{ 
		if (Input.GetKeyDown ("p"))
			//This calls the function contained in the AudioManager script that plays a sound effect. The approprate audio clip should be passed as an argument.
			AudioManager.instance.PlaySound (normalHit);

		if (Input.GetKeyDown ("c"))
			AudioManager.instance.PlaySound (critHit);
	}
}
