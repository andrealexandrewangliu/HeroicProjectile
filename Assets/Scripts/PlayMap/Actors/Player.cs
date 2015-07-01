using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public static GameObject PlayerObject;
	public GameObject Shield;

	public bool IsDazed{
		get{
			Daze daze = GetComponent<Daze> ();
			if (daze != null){
				return daze.enabled;
			}
			return false;
		}
	}

	void Start(){
		PlayerObject = this.gameObject;
	}

	void Update(){
		Shield.SetActive (LevelGlobals.Invincible);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Ally_Wander") {
			PartyMember.AddPartyMember(coll.gameObject);
		}
		else  if (coll.gameObject.tag == "Ally_Projectile") {
		}
		else  if (coll.gameObject.tag == "Enemy") {
		}
		else  if (coll.gameObject.tag == "Enemy_Projectile") {
		}
	}
}
