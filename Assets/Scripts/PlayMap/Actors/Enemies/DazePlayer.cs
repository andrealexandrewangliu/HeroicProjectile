using UnityEngine;
using System.Collections;

public class DazePlayer : MonoBehaviour {
	public float DazeTime = 1;
	public PlayEmote EmotePlayer;

	void Start(){
		DazeTime -= 0.16f * (BaseGlobalStats.SuccubusLvl);
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.GetComponent<Daze> ().DazePlayer(DazeTime);
			EmotePlayer.Love ();
			enabled = false;
		}
	}
}
