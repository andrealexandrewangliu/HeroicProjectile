using UnityEngine;
using System.Collections;

public class UniqueObject : MonoBehaviour {
	private static Hashtable ObjectTable = new Hashtable();
	public string Key;

	// Use this for initialization
	void Start () {
		ObjectTable [Key] = this.gameObject;
	}

	public bool UniqueIsActive(){
		return ObjectTable [Key] != null;
	}


	void OnDestroy() {
		ObjectTable [Key] = null;
	}
}
