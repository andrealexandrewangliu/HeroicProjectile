using UnityEngine;
using System.Collections;

public class PlayerTargetable : MonoBehaviour {
	public float HP = 20;

	// Use this for initialization
	public static GameObject[] TargetableList{
		get{
			return GameObject.FindGameObjectsWithTag("Enemy");
		}
	}

	public void Damage(float damage){
		HP -= damage;
		if (HP <= 0)
			Die ();
	}

	public void Die(){
		GameObject.Destroy (gameObject);
	}

	public static GameObject ClosestTo(Vector3 Point){
		GameObject returnObject = null;
		float newd, distance = -1;
		foreach (GameObject compareObject in TargetableList) {
			newd = Vector3.Distance(compareObject.transform.position, Point);
			if (returnObject == null || newd < distance){
				returnObject = compareObject;
				distance = newd;
			}
		}

		return returnObject;
	}
}
