using UnityEngine;
using System.Collections;

public class PowerCounter : MonoBehaviour {
	private UnityEngine.UI.Text textScript;
	void Start(){
		textScript = GetComponent<UnityEngine.UI.Text> ();
	}
	// Update is called once per frame
	void Update () {
		textScript.text = LevelGlobals.PowerString;
	}
}
