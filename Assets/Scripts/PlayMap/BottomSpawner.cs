using UnityEngine;
using System.Collections;

public class BottomSpawner : CumulativeSpawner {
	public GameObject parentSpawn;
	public GameObject borderMinus;
	public GameObject borderPlus;

	protected override void Spawn(GameObject spawnPrefab){
		Vector2 bMinus = borderMinus.transform.position;
		Vector2 bPlus = borderPlus.transform.position;
		float scale = LevelGlobals.StageScale;
		float x = Random.Range (bMinus.x, bPlus.x);
		float y = bMinus.y - (2 * scale);
		UniqueObject unique = spawnPrefab.GetComponent<UniqueObject> ();
		if (unique == null || !unique.UniqueIsActive ()) {
			GameObject spawn = (GameObject)Instantiate (spawnPrefab, 
		                                            new Vector3 (x, y, parentSpawn.transform.position.z), 
		                                            Quaternion.identity);
			spawn.GetComponent<MoveToDestination2D> ().Destination2D = new Vector2 (x, bPlus.y + (2 * scale));
			spawn.transform.parent = parentSpawn.transform;
			spawn.transform.localScale = new Vector3 (1, 1, 1);
		}
	}

}
