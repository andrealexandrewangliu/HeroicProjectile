using UnityEngine;
using System.Collections;

public class DestroyInSeconds : MonoBehaviour {
	public float SecondsLimit = 10;
	private float SecondsPassed = 0;
	
	// Update is called once per frame
	void Update () {
		// START Heroic Projectile Global
		if (LevelGlobals.Paused)
			return;
		// END Heroic Projectile Global

		SecondsPassed += Time.deltaTime;
		if (SecondsPassed >= SecondsLimit) {
			GameObject.Destroy(this.gameObject);
		}
	}
}
