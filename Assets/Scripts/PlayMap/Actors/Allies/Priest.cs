using UnityEngine;
using System.Collections;

public class Priest : PartyMember {
	public float InvincibleTime = 1;
	public GameObject Aura;
	public GameObject Effect;
	public static int PriestCount = 0;
	private static float PriestAttritionStall = 0.05f;
	public static float TotalPriestBonus{
		get{
			return PriestAttritionStall * (float) PriestCount;
		}
	}

	#region implemented abstract members of PartyMember
	public override void UseAbility ()
	{
		RemoveFromParty ();
		LevelGlobals.InvincibleTimer = InvincibleTime;
		Aura.SetActive (true);
		Effect.SetActive (true);
		Effect.transform.parent = Player.PlayerObject.transform;
		Effect.transform.localPosition = new Vector3 (0, 0, 0);
		GetComponent<SpriteRenderer> ().enabled = false;
	}
	#endregion

	protected override void EnterParty ()
	{
		PriestCount++;
	}

	protected override void LeaveParty ()
	{
		PriestCount--;
	}

	// Use this for initialization
	void Start () {
		InvincibleTime = 1 + BaseGlobalStats.PriestLvl;
		switch (BaseGlobalStats.PriestLvl) {
		case 0:	
			PriestAttritionStall = 0.05f;
			break;
		case 1:	
			PriestAttritionStall = 0.08f;
			break;
		case 2:	
			PriestAttritionStall = 0.11f;
			break;
		case 3:	
			PriestAttritionStall = 0.15f;
			break;
		case 4:	
			PriestAttritionStall = 0.2f;
			break;
		case 5:	
			PriestAttritionStall = 0.25f;
			break;
		}
	}
}
