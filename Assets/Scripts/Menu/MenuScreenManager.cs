using UnityEngine;
using System.Collections;

public class MenuScreenManager : CutsceneEndTrigger {
	public GameObject Stage;
	public GameObject SceneManager;
	public GameObject SceneIntro;
	public GameObject SceneMenu;
	public MusicBGMPlayer MusicPlayer;
	public AudioClip BGMClip;

	// Use this for initialization
	void Start () {
		if (!BaseGlobalStats.Intro) {
			Stage.SetActive (false);
			if (BaseGlobalStats.MaxLevel < 0) {
				GameObject scene = (GameObject)Instantiate (SceneIntro);
				scene.transform.parent = SceneManager.transform;
				scene.GetComponent<CutscenePlayer>().EndTrigger = this;
			} else {
				MusicPlayer.PlayNow(BGMClip);
				BaseGlobalStats.Intro = true;
				// RETURN MENU TUTORIAL CUTSCENE
				CutsceneEndFunction ();
			}
		} 
		else {
			Stage.SetActive(true);
			MusicPlayer.PlayNow(BGMClip);
		}
	}

	public void StartGame(){
		Application.LoadLevel("PlayMap");
	}

	#region implemented abstract members of CutsceneEndTrigger

	protected override void CutsceneEndFunction ()
	{
		if (!BaseGlobalStats.Intro) {
			Stage.SetActive (false);
			if (BaseGlobalStats.MaxLevel < 0) {
				StartGame();
			}
		}
		else {
			Stage.SetActive(true);
			BaseGlobalStats.SavePersistentData ();
		}

	}

	#endregion
}
