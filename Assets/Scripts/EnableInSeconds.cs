using UnityEngine;
using System.Collections;

public class EnableInSeconds : MonoBehaviour {
	public MonoBehaviour Script;
	public float EnableTime = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// START Heroic Projectile Global
		if (LevelGlobals.Paused)
			return;
		// END Heroic Projectile Global

		if (EnableTime > 0) {
			EnableTime -= Time.deltaTime;
			if (EnableTime <= 0){
				EnableTime = 0;
				Script.enabled = true;
			}
		}
	}
}
