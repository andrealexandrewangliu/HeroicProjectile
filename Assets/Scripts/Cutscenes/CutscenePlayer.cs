using UnityEngine;
using System.Collections;

public abstract class CutscenePlayer : MonoBehaviour {
	public MusicBGMPlayer MusicPlayer;
	public AudioClip[] Tracks;
	public ActorManager[] ActorPlayer = new ActorManager[1];
	public CutsceneTextbox Textbox;
	public CutsceneEndTrigger EndTrigger;
	protected float NextSceneInSeconds = 0;  
	protected int SceneIndex = 0;

	public void PlayMusic(int i){
		if (i>=0)
			MusicPlayer.Play (Tracks [i]);
		else
			MusicPlayer.Play (null);
	}

	public void SwitchScene(int i){
		foreach (ActorManager player in ActorPlayer) {
			if (player.gameObject.activeSelf){
				player.NoEmoteAllActors();
				player.WarpAllActors ();
				player.gameObject.SetActive(false);
			}
		}
		ActorPlayer[i].gameObject.SetActive(true);
	}

	public void NextScene(){
		NextSceneInSeconds = 0;
		foreach (ActorManager player in ActorPlayer) {
			player.WarpAllActors ();
		}
		ProcessNextScene ();
		SceneIndex++;
	}

	protected abstract void ProcessNextScene();

	public void EndScene(){
		if (EndTrigger != null) {
			EndTrigger.CutsceneEnd ();
		}
		GameObject.Destroy (this.gameObject);
	}

	public void CloseText(){
		Textbox.Close();
	}

	public void WriteText(string text){
		Textbox.WriteText (text);
	}
	
	public void WriteText(string title, string text){
		Textbox.WriteText (title, text);
	}

	void Start(){
		NextSceneInSeconds = 0.01f;
	}

	void Update(){
		if (NextSceneInSeconds > 0) {
			NextSceneInSeconds -= Time.deltaTime;
			if (NextSceneInSeconds <=0){
				NextSceneInSeconds = 0;
				NextScene();
			}
		}
	}
}
