using UnityEngine;
using System.Collections;

public class DestroyWhenTrue : MonoBehaviour {
	public bool DestroyActive = false;

	void Start(){
		DestroyActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (DestroyActive) {
			Debug.Log(DestroyActive);
			GameObject.Destroy (this.gameObject);
		}
	}
}
