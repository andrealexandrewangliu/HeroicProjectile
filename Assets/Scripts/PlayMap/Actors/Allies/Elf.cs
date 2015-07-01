using UnityEngine;
using System.Collections;

public class Elf : PartyMember {
	public PlayEmote Emote;

	#region implemented abstract members of PartyMember
	public override void UseAbility ()
	{
		RemoveFromParty ();
		MoveToDestination2D mover = GetComponent<MoveToDestination2D> ();
		SpreadRangedAttack attack = GetComponent<SpreadRangedAttack> ();
		mover.enabled = true;
		Vector2 destination = mover.Destination2D;
		destination.x = transform.position.x;
		destination.y = LevelGlobals.LocalGlobals.EnemySpawner.borderMinus.transform.position.y - 5 * LevelGlobals.StageScale;
		mover.Destination2D = destination;
		attack.enabled = true;
		attack.Projectiles = 15;
		attack.FireRate = 30;
		attack.Ammo = 10;
		Emote.Angry ();
	}
	#endregion

	// Use this for initialization
	void Start () {
		RangedAttack attack = GetComponent<RangedAttack> ();
		attack.Strength = 5 + BaseGlobalStats.ElfLvl;
		switch (BaseGlobalStats.ElfLvl) {
		case 0:
			attack.FireRate = 0.8f;
			break;
		case 1:
			attack.FireRate = 1.2f;
			break;
		case 2:
			attack.FireRate = 1.6f;
			break;
		case 3:
			attack.FireRate = 2.2f;
			break;
		case 4:
			attack.FireRate = 3.0f;
			break;
		case 5:
			attack.FireRate = 4.0f;
			break;
		}
	}
}
