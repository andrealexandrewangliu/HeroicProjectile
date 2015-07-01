using UnityEngine;
using System.Collections;

public class MusicBGMPlayer : MonoBehaviour {
	public float TransitionTime;

	private AudioSource AudioPlayer;
	private AudioClip NextMusic = null;
	private float TargetVolume = 0;

	private float TransitionPerSec{
		get{
			return TargetVolume / (TransitionTime / 2.0f);
		}
	}
	
	public void PlayNow(AudioClip music){
		AudioPlayer.clip = music;
		AudioPlayer.Play();
	}
	
	public void Play(AudioClip music){
		NextMusic = music;
		TargetVolume = AudioPlayer.volume;
	}

	// Use this for initialization
	void Start () {
		AudioPlayer = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (TargetVolume > 0) {
			float volumeShift = Time.deltaTime * TransitionPerSec;
			if (NextMusic != null){
				if (AudioPlayer.volume > volumeShift){
					AudioPlayer.volume -= volumeShift;
				}
				else{
					AudioPlayer.volume = volumeShift - AudioPlayer.volume;
					AudioPlayer.clip = NextMusic;
					AudioPlayer.Play();
					NextMusic = null;
				}
			}
			else{
				AudioPlayer.volume += Time.deltaTime * TransitionPerSec;
				if (TargetVolume < AudioPlayer.volume){
					AudioPlayer.volume = TargetVolume;
					TargetVolume = 0;
				}
			}
		}
	}
}
