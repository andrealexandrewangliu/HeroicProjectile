using UnityEngine;
using System.Collections;

public class Guard : PartyMember {
	public GameObject MeleeAttack;
	public GameObject Aura;
	public GameObject SpecialAttack;

	#region implemented abstract members of PartyMember
	public override void UseAbility ()
	{
		RemoveFromParty ();
		MoveToDestination2D mover = GetComponent<MoveToDestination2D> ();
		mover.enabled = true;
		Vector2 destination = mover.Destination2D;
		destination.x = transform.position.x;
		destination.y = LevelGlobals.LocalGlobals.EnemySpawner.borderPlus.transform.position.y;
		mover.Destination2D = destination;
		MeleeAttack.SetActive (false);
		Aura.SetActive (true);
		SpecialAttack.SetActive (true);
	}
	#endregion

	// Use this for initialization
	void Start () {
		Attack attack = MeleeAttack.GetComponent<Attack> ();
		switch (BaseGlobalStats.GuardLvl) {
		case 0:
			attack.Strength = 10;
			break;
		case 1:
			attack.Strength = 20;
			break;
		case 2:
			attack.Strength = 30;
			break;
		case 3:
			attack.Strength = 50;
			break;
		case 4:
			attack.Strength = 70;
			break;
		case 5:
			attack.Strength = 100;
			break;
		}
		SpecialAttack.GetComponent<Attack> ().Strength = attack.Strength;
	}
}
