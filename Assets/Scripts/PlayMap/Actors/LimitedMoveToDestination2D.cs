using UnityEngine;
using System.Collections;

public class LimitedMoveToDestination2D : MoveToDestination2D {
	public PlayerControls PlayerController; 

	override
	public Vector2 Destination2D{
		set{
			Destination = value;

			if (Destination.x > PlayerController.borderPlus.transform.position.x) {
				Destination.x = PlayerController.borderPlus.transform.position.x;
			} 
			else if (Destination.x < PlayerController.borderMinus.transform.position.x) {
				Destination.x = PlayerController.borderMinus.transform.position.x;
			}
			if (Destination.y > PlayerController.borderPlus.transform.position.y) {
				Destination.y = PlayerController.borderPlus.transform.position.y;
			} 
			else if (Destination.y < PlayerController.borderMinus.transform.position.y) {
				Destination.y = PlayerController.borderMinus.transform.position.y;
			}

			Active = true;
		}
		get{
			return Destination;
		}
	}

	public void CorrectPosition(){
		Vector3 Position = transform.position;
		
		if (Position.x > PlayerController.borderPlus.transform.position.x) {
			Position.x = PlayerController.borderPlus.transform.position.x;
		} 
		else if (Position.x < PlayerController.borderMinus.transform.position.x) {
			Position.x = PlayerController.borderMinus.transform.position.x;
		}
		if (Position.y > PlayerController.borderPlus.transform.position.y) {
			Position.y = PlayerController.borderPlus.transform.position.y;
		} 
		else if (Position.y < PlayerController.borderMinus.transform.position.y) {
			Position.y = PlayerController.borderMinus.transform.position.y;
		}

		transform.position = Position;
	}
}
