using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	public AudioClip menuClip;
	public AudioClip backgroundClip;

	private AudioSource music;
	// Use this for initialization
	void Start () {
		if(instance != null && instance != this){
			Destroy(gameObject);
		}else{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = menuClip;
			music.loop = true;
			music.Play();
		}
	}

	void OnLevelWasLoaded(int level){
		//music.Stop();

		if(level == 1){
			music.clip = menuClip;
		}
		if(level == 2){
			music.clip = backgroundClip;
		}
		music.loop = true;
		music.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
