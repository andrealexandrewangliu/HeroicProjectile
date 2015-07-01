using UnityEngine;
using System.Collections;

public class DirectHoming : MonoBehaviour {
	private GameObject Target;
	private MoveToDestination2D moverScript;
	
	
	void Start(){
		moverScript = GetComponent<MoveToDestination2D> ();
		if (gameObject.tag == "Ally_Projectile") {
			Target = PlayerTargetable.ClosestTo(transform.position);
		}
		else if (gameObject.tag == "Enemy_Projectile") {
			Target = Player.PlayerObject;
		}
		else if (gameObject.tag == "Enemy") {
			Target = Player.PlayerObject;
		}
		else if (gameObject.tag == "Ally_Wander") {
			Target = Player.PlayerObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Target == null && gameObject.tag == "Ally_Projectile") {
			Target = PlayerTargetable.ClosestTo(transform.position);
		}
		if (!LevelGlobals.Paused && Target != null) {
			Vector3 targetX = Target.transform.position;

			moverScript.Destination2D = new Vector2(targetX.x, targetX.y);
		}

	}
}
