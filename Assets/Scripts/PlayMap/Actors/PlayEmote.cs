using UnityEngine;
using System.Collections;

public class PlayEmote : MonoBehaviour {
	public Animator Balloon;
	// Use this for initialization
	
	public void Suprised(){
		Balloon.Play ("Suprised");
	}
	
	public void Sleep(){
		Balloon.Play ("Sleep");
	}
	
	public void Idea(){
		Balloon.Play ("Idea");
	}
	
	public void Silence(){
		Balloon.Play ("Silence");
	}
	
	public void Frustration(){
		Balloon.Play ("Frustration");
	}
	
	public void SweatDrop(){
		Balloon.Play ("SweatDrop");
	}
	
	public void Angry(){
		Balloon.Play ("Angry");
	}
	
	public void Love(){
		Balloon.Play ("Love");
	}
	
	public void Happy(){
		Balloon.Play ("Happy");
	}
	
	public void Question(){
		Balloon.Play ("Question");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
