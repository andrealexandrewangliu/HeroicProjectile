using UnityEngine;
using System.Collections;

public class PushBack : MonoBehaviour {
	public float Distance;
	private bool Friendly;
	
	void Start () {
		Friendly = (tag == "Ally") || (tag == "Ally_Wander");
	}

	public float FinalDistance{
		get{
			return Distance / (float)(1 + BaseGlobalStats.OrcLvl);
		}
	}
	
	void OnTriggerStay2D(Collider2D coll) {
		if (Friendly) {
			if (coll.gameObject.tag == "Enemy") {
				Vector3 direction = (coll.gameObject.transform.position - transform.position).normalized;
				coll.gameObject.transform.position += direction * FinalDistance;
			}
		} 
		else {
			if (coll.gameObject.tag == "Player") {
				Vector3 direction = (coll.gameObject.transform.position - transform.position).normalized;
				coll.gameObject.transform.position += direction * FinalDistance;
			}
		}
	}
}
