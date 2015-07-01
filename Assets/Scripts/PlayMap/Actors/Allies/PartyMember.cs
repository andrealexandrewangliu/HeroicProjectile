using UnityEngine;
using System.Collections;

public abstract class PartyMember : MonoBehaviour {
	public static ArrayList CurrentParty = new ArrayList();
	public int Position = -1;
	public bool Kicked = false;
	
	public abstract void UseAbility ();
	protected virtual void EnterParty (){}
	protected virtual void LeaveParty (){}
	private MoveToDestination2D Mover;
	
	public static void ClearParty(){
		CurrentParty.Clear ();
	}

	public void ActivateMember() {
		GetComponent<MoveToDestination2D> ().KillOnInactive = false;
		Transform melee = transform.FindChild("MeleeAttack");
		if (melee != null) {
			melee.gameObject.SetActive(true);
		}
		RangedAttack range = GetComponent<RangedAttack> ();
		if (range != null) {
			range.enabled = true;
		}
		EnterParty ();
	}
	
	public static GameObject AddPartyMember(GameObject member){
		GameObject remove = null;
		member.tag = "Ally";
		member.GetComponent<PartyMember> ().Position = CurrentParty.Count;
		member.GetComponent<PartyMember> ().ActivateMember ();
		CurrentParty.Add(member);
		if (CurrentParty.Count > 4) {
			remove =(GameObject) CurrentParty[0];
			remove.GetComponent<PartyMember>().Kick();
		}
		PartyUpdateList ();
		return remove;
	}
	
	public static void UpdatePositions(){
		for (int i = 0; i < CurrentParty.Count; i++) {
			GameObject member = (GameObject) CurrentParty[i];
			PartyMember specs = member.GetComponent<PartyMember>();
			specs.Position = i;
		}
	}
	public void KillMember(){
		if (!LevelGlobals.Invincible) {
			RemoveFromParty ();
			GameObject.Destroy (gameObject);
			PartyUpdateList ();
		}
	}
	
	public void RemoveFromParty(){
		tag = "Ally_Kicked";
		Kicked = true;
		GetComponent<MoveToDestination2D> ().KillOnInactive = true;
		if (Position >= 0 && Position < CurrentParty.Count) {
			CurrentParty.RemoveAt (Position);
		}
		Position = -1;
		GetComponent<BoxCollider2D> ().enabled = false;
		GetComponent<DestroyInSeconds> ().enabled = true;
		Transform melee = transform.FindChild("MeleeAttack");
		if (melee != null) {
			melee.gameObject.SetActive(false);
		}
		RangedAttack range = GetComponent<RangedAttack> ();
		if (range != null) {
			range.enabled = false;
		}
		UpdatePositions();
		LeaveParty ();
	}

	public void Kick(){
		Vector2 kickDirection = new Vector2 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f)).normalized;
		MoveToDestination2D mover = GetComponent<MoveToDestination2D> ();
		RemoveFromParty ();
		mover.enabled = true;
		mover.Speed = 10;
		mover.Destination2D = new Vector2(transform.position.x, transform.position.y) + (kickDirection * 1000 * LevelGlobals.StageScale);
		PartyUpdateList ();
	}

	public static void PartyUpdateList(){
		GameObject.Find ("/Canvas/Actions").GetComponent<ActionButtonUpdate> ().UpdateButtons ();
	}
	
	// Update is called once per frame
	// Position with x = 0.7 and y = -abs(0.3) offset;
	void Update () {
		if (LevelGlobals.Paused)
			return;
		if (Position >= 0) {
			Vector3 newPosition = Player.PlayerObject.transform.position;
			MoveToDestination2D mover = GetComponent<MoveToDestination2D> ();
			switch (Position) {
			case 0:
				newPosition = newPosition + new Vector3 (0.7f, -0.3f, 0) * LevelGlobals.StageScale;
				break;
			case 1:
				newPosition = newPosition + new Vector3 (-0.7f, -0.3f, 0) * LevelGlobals.StageScale;
				break;
			case 2:
				newPosition = newPosition + new Vector3 (1.4f, -0.6f, 0) * LevelGlobals.StageScale;
				break;
			case 3:
				newPosition = newPosition + new Vector3 (-1.4f, -0.6f, 0) * LevelGlobals.StageScale;
				break;
			}
			mover.Destination2D = new Vector2 (newPosition.x, newPosition.y);
		}
	}


}
