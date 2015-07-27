using UnityEngine;
using System.Collections;

public class TitleMenu : MonoBehaviour {
	public Animator TitleBomb;
	public AudioSource TitleSound;
	public AudioSource BGM;
	public float FadeoutTime = 2;
	public UnityEngine.UI.Image FadeoutBlanket;
	private UpdateAction UpdateNext = UpdateAction.None;

	public enum UpdateAction
	{
		None,
		StartFade,
		Start
	};

	public void StartGame(){
		TitleBomb.Play ("TitleBomb");
		TitleSound.Play ();
		BGM.Stop ();
		FadeoutBlanket.gameObject.SetActive (true);
		UpdateNext = UpdateAction.StartFade;
	}

	void Update(){
		float time = Time.deltaTime;
		switch (UpdateNext) {
		case UpdateAction.StartFade:
			Color fadecolor = FadeoutBlanket.color;
			fadecolor.a += time / FadeoutTime;
			if (fadecolor.a >= 1){
				fadecolor.a = 1;
				UpdateNext = UpdateAction.Start;
			}
			FadeoutBlanket.color = fadecolor;
			break;
		case UpdateAction.Start:
			Application.LoadLevel("Menu");
			break;
		}

	}
}
