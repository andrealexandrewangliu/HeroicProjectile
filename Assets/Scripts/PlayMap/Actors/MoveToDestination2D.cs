using UnityEngine;
using System.Collections;

public class MoveToDestination2D : MonoBehaviour {
	public float Speed = 5;
	protected Vector2 Destination;
	public bool Active = false;
	public bool KillOnInactive = true;
	public bool RotateDirection = false;

	public virtual Vector2 Destination2D{
		set{
			Destination = value;
			Active = true;
		}
		get{
			return Destination;
		}
	}
	
	public Vector2 Direction2D{
		get{
			return (Destination - new Vector2(transform.position.x, transform.position.y)).normalized;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Active && !LevelGlobals.Paused) {
			float overallSpeed = Speed * LevelGlobals.StageScale;
			Vector3 destination = new Vector3(Destination.x, Destination.y, transform.position.z);
			Vector3 direction = (destination - transform.position).normalized;
			Vector3 moveDestination = transform.position + direction * overallSpeed * Time.deltaTime;
			moveDestination.z = transform.position.z;
			if (RotateDirection){
				transform.up = direction;
			}

			if (Vector3.Distance (destination, transform.position) > Vector3.Distance (moveDestination, transform.position)) {
				transform.position = moveDestination;
			} 
			else {
				transform.position = destination;
				Active = false;
				if (KillOnInactive)
					GameObject.Destroy(this.gameObject);
			}
		}
	}
}
