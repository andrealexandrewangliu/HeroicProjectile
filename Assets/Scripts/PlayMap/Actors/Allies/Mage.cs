using UnityEngine;
using System.Collections;

public class Mage : PartyMember {
	public GameObject MageNukePrefab;
	public GameObject Aura;

	private void MageBlown(Vector3 centerPoint){
		Vector3 blowDirection = (transform.position - centerPoint).normalized;
		Vector2 blowDirection2D = new Vector2 (blowDirection.x, blowDirection.y);
		MoveToDestination2D mover = GetComponent<MoveToDestination2D> ();
		RemoveFromParty ();
		mover.enabled = true;
		mover.Speed = 10;
		mover.Destination2D = new Vector2(transform.position.x, transform.position.y) + (blowDirection2D * 1000 * LevelGlobals.StageScale);
		PartyUpdateList ();
	}

	#region implemented abstract members of PartyMember
	public override void UseAbility ()
	{
		Aura.SetActive (true);
		var bMinus = LevelGlobals.LocalGlobals.AllySpawner.borderMinus.transform.position;
		var bPlus = LevelGlobals.LocalGlobals.AllySpawner.borderPlus.transform.position;
		Vector3 centerPoint = (bMinus + bPlus) / 2.0f;
		centerPoint.z = 0;
		MageBlown (centerPoint);

		GameObject nuke = (GameObject) Instantiate(MageNukePrefab, 
		                                           centerPoint, 
		                                           Quaternion.identity);
		nuke.transform.parent = transform.parent;
		nuke.transform.localScale = new Vector3 (5, 5, 5);
		nuke.transform.position = centerPoint;
		Vector3 local = nuke.transform.localPosition;
		local.z = 0;
		nuke.transform.localPosition = local;
	}
	#endregion

	// Use this for initialization
	void Start () {
		RangedAttack attack = GetComponent<RangedAttack> ();
		attack.Speed = 5 + BaseGlobalStats.MageLvl;
		attack.FireRate = 1.0f + 0.1f * BaseGlobalStats.MageLvl;
		switch (BaseGlobalStats.MageLvl) {
		case 0:
			attack.Strength = 8;
			break;
		case 1:
			attack.Strength = 11;
			break;
		case 2:
			attack.Strength = 14;
			break;
		case 3:
			attack.Strength = 17.5f;
			break;
		case 4:
			attack.Strength = 21;
			break;
		case 5:
			attack.Strength = 25;
			break;
		}
	}
}
