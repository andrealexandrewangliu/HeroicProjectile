using UnityEngine;
using System.Collections;

public abstract class CumulativeSpawner : MonoBehaviour {
	public int SpawnLevel = 0;
	public GameObject[] SpawnObjects = new GameObject[5];
	public float[] ChancePerDeciSecond = new float[5];
	private float ElapsedSeconds = 0;

	protected abstract void Spawn (GameObject spawnPrefab);

	// Use this for initialization
	private void SelectSpawn () {
		int spawnMax = Mathf.Min(SpawnLevel, Mathf.Min(SpawnObjects.Length, ChancePerDeciSecond.Length));
		for (int i = 0; i < spawnMax; i++){
			if (Random.Range(0.0f,1.0f) <= ChancePerDeciSecond[i]){
				Spawn(SpawnObjects[i]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelGlobals.Paused)
			return;

		ElapsedSeconds += Time.deltaTime;
		while (ElapsedSeconds >= 0.1f) {
			ElapsedSeconds -= 0.1f;
			SelectSpawn();
		}
	}
}
