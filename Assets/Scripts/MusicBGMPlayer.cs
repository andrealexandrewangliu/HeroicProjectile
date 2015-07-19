using UnityEngine;
using System.Collections;

public class MusicBGMPlayer : MonoBehaviour {
	public float TransitionTime;

	private AudioSource AudioPlayer;
	public AudioClip NextMusic = null;
	public float TargetVolume = 0;

	private float TransitionPerSec{
		get{
			return TargetVolume / (TransitionTime / 2.0f);
		}
	}
	
	public void PlayNow(AudioClip music){
		init ();
		AudioPlayer.clip = music;
		AudioPlayer.Play();
	}
	
	public void Play(AudioClip music){
		init ();
		NextMusic = music;
		if (TargetVolume == 0) {
			if (NextMusic == null)
				TargetVolume = -AudioPlayer.volume;
			else
				TargetVolume = AudioPlayer.volume;
		} else {
			if (AudioPlayer.volume <= 0){
				AudioPlayer.clip = NextMusic;
				AudioPlayer.Play();
				NextMusic = null;
			}
		}
	}

	public void init(){
		if (AudioPlayer == null) {
			AudioPlayer = GetComponent<AudioSource> ();
		}
	}

	// Use this for initialization
	void Start () {
		init ();
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
				AudioPlayer.volume += volumeShift;
				if (TargetVolume < AudioPlayer.volume){
					AudioPlayer.volume = TargetVolume;
					TargetVolume = 0;
				}
			}
		}
		else if (TargetVolume < 0) {
			float volumeShift = Time.deltaTime * TransitionPerSec;
			if (AudioPlayer.volume > 0){
				AudioPlayer.volume += volumeShift;
			}
			else{
				AudioPlayer.volume = 0;
				AudioPlayer.clip = NextMusic;
				AudioPlayer.Play();
				NextMusic = null;
				TargetVolume = -TargetVolume;
			}
		}
	}
}
