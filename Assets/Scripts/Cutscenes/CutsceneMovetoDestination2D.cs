using UnityEngine;
using System.Collections;

public class CutsceneMovetoDestination2D : MoveToDestination2D {

	public void WarpToDestination(){
		transform.localPosition = new Vector3(Destination.x, Destination.y, transform.position.z);
		Active = false;
		if (KillOnInactive)
			GameObject.Destroy(this.gameObject);
	}

	// Update is called once per frame
	void Update () {
		if (Active && !LevelGlobals.Paused) {
			Vector3 destination = new Vector3(Destination.x, Destination.y, transform.position.z);
			Vector3 direction = (destination - transform.localPosition).normalized;
			Vector3 moveDestination = transform.localPosition + direction * Speed * Time.deltaTime;
			moveDestination.z = transform.localPosition.z;
			if (RotateDirection){
				transform.up = direction;
			}
			
			if (Vector3.Distance (destination, transform.localPosition) > Vector3.Distance (moveDestination, transform.localPosition)) {
				transform.localPosition = moveDestination;
			} 
			else {
				transform.localPosition = destination;
				Active = false;
				if (KillOnInactive)
					GameObject.Destroy(this.gameObject);
			}
		}
	}
}
