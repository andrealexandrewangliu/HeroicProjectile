using UnityEngine;
using System.Collections;

public class Daze : MonoBehaviour {
	public float DazedRemainingTime = 0;
	private QuakeMovement Quaker;
	public PlayEmote EmotePlayer;

	void Start(){
		Quaker = GetComponent<QuakeMovement> ();
	}

	public void DazePlayer(float time){
		DazedRemainingTime = time;
		enabled = true;
		Quaker.CheckQuakeCondition ();
		if (ImoutoStickToPlayer.IsImoutoStuck) {
			EmotePlayer.SweatDrop ();
			ImoutoStickToPlayer.ImoutoStuckObject.GetComponent<ImoutoStickToPlayer> ().EmotePlayer.Angry();
		} else {
			EmotePlayer.Love ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (LevelGlobals.Paused)
			return;
		if (DazedRemainingTime <= 0) {
			DazedRemainingTime = 0;
			enabled = false;
		} 
		else {
			DazedRemainingTime -= Time.deltaTime;
			MoveToDestination2D mover = GetComponent<MoveToDestination2D>();
			Vector2 direction = mover.Direction2D;
			mover.Destination2D = new Vector2(transform.position.x, transform.position.y) + (direction * 1000 * mover.Speed);
		}
	}
}
