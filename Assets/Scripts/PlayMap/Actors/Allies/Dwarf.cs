using UnityEngine;
using System.Collections;

public class Dwarf : PartyMember {
	public ExtraEngine Engine;

	#region implemented abstract members of PartyMember
	public override void UseAbility ()
	{
		RemoveFromParty ();
		MoveToDestination2D mover = GetComponent<MoveToDestination2D> ();
		mover.enabled = true;
		Vector2 destination = mover.Destination2D;
		destination.x = transform.position.x;
		destination.y = LevelGlobals.LocalGlobals.EnemySpawner.borderMinus.transform.position.y - 5 * LevelGlobals.StageScale;
		mover.Destination2D = destination;
		Engine.enabled = true;
		Engine.transform.parent = Player.PlayerObject.transform;
		Engine.transform.localPosition = new Vector3(0, -0.2f, 0);
	}
	#endregion

	// Use this for initialization
	void Start () {
		Engine.GetComponent<TrailEffect> ().Parent = transform.parent;
		RangedAttack attack = GetComponent<RangedAttack> ();
		switch (BaseGlobalStats.DwarfLvl) {
		case 0:
			attack.Strength = 0.5f;
			break;
		case 1:
			attack.Strength = 0.7f;
			break;
		case 2:
			attack.Strength = 0.9f;
			break;
		case 3:
			attack.Strength = 1.2f;
			break;
		case 4:
			attack.Strength = 1.5f;
			break;
		case 5:
			attack.Strength = 2;
			break;
		}
		Engine.Strength = attack.Strength;
	
	}
}
