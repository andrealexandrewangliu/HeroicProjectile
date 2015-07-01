using UnityEngine;
using System.Collections;

public class ImoutoStickToPlayer : MonoBehaviour {
	public PlayEmote EmotePlayer;
	public float StickTime = 10;
	private GameObject Player;
	private float StuckFor = 0;
	public static ImoutoStickToPlayer ImoutoStuckObject = null;
	public static bool IsImoutoStuck{
		get{
			return ImoutoStuckObject != null;
		}
	}

	void Start(){
		StickTime = 10 -  1.6f * BaseGlobalStats.ImoutoLvl;
	}

	// Update is called once per frame
	void Update () {
		if (Player != null) {
			StuckFor += Time.deltaTime;
			if (StuckFor > StickTime){
				Unstick();
			}
		}
	}

	void Unstick(){
		ImoutoStuckObject = null;
		transform.parent = Player.transform.parent;
		transform.localEulerAngles = new Vector3 (0, 0, 180);
		
		gameObject.GetComponent<MoveToDestination2D>().enabled = true;
		Vector2 exitPoint = gameObject.GetComponent<MoveToDestination2D> ().Destination2D;
		exitPoint.x = transform.position.x;
		gameObject.GetComponent<MoveToDestination2D> ().Destination2D = exitPoint;
		Player.GetComponent<MoveToDestination2D> ().Speed = BaseGlobalStats.PlayerSpeed;
	}


	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			Player = coll.gameObject;
			ImoutoStuckObject = this;
			transform.localEulerAngles = new Vector3 (0, 0, 0);
			transform.parent = Player.transform;
			transform.position = Player.transform.position;
			gameObject.GetComponent<MoveToDestination2D>().enabled = false;
			gameObject.GetComponent<HorizontalHomingStrafing>().enabled = false;
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
			Player.GetComponent<MoveToDestination2D> ().Speed = BaseGlobalStats.PlayerSpeed / 2;
			QuakeMovement quaker = Player.GetComponent<QuakeMovement> ();
			quaker.CheckQuakeCondition();
			if (quaker.QuakeMovementCondition){
				EmotePlayer.Angry();
				Player.GetComponent<Daze> ().EmotePlayer.SweatDrop ();
			}
			else{
				EmotePlayer.Happy();
				Player.GetComponent<Daze> ().EmotePlayer.Frustration ();
			}
		}
	}
}
