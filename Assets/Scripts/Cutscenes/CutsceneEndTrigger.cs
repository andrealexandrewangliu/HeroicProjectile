using UnityEngine;
using System.Collections;

public abstract class CutsceneEndTrigger : MonoBehaviour {
	private bool End = false;

	public void CutsceneEnd (){
		End = true;
	}

	protected abstract void CutsceneEndFunction ();

	void LateUpdate(){
		if (End) {
			End = false;
			CutsceneEndFunction ();
		}
	}
}
