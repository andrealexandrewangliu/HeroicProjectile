using UnityEngine;
using System.Collections;

public class PauseAnimationSynchronizer : MonoBehaviour {
	private Animator AnimatorSync;
	// Use this for initialization
	void Start () {
		AnimatorSync = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		AnimatorSync.enabled = !LevelGlobals.Paused;
	}
}
