using UnityEngine;
using System.Collections;

public class HorizontalHomingStrafing : MonoBehaviour {
	public float Speed = 5;
	public GameObject Target;
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
		else if (gameObject.tag == "Enemy_NonTargetable") {
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
			float overallSpeed = Speed * LevelGlobals.StageScale * Time.deltaTime;
			float targetX = Target.transform.position.x;
			float newX = transform.position.x;

			if (targetX > newX){
				if (targetX > (newX + overallSpeed)){
					newX += overallSpeed;
				} 
				else {
					newX = targetX;
				}
			}
			else if (targetX < newX){
				if (targetX < (newX - overallSpeed)){
					newX -= overallSpeed;
				} 
				else {
					newX = targetX;
				}
			}
			Vector3 temp = transform.position;
			temp.x = newX;
			transform.position = temp;
			Vector2 dest2D = moverScript.Destination2D;
			dest2D.x = newX;
			moverScript.Destination2D = dest2D;

		}
	}
}
