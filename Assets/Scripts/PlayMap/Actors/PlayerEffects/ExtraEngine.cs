using UnityEngine;
using System.Collections;

public class ExtraEngine : MonoBehaviour {
	public GameObject ExplosionPrefab;
	public float Strength = 1;
	private float EnginePower = 10;
	private float EngineFuel = 10;

	void Start(){
		switch (BaseGlobalStats.DwarfLvl) {
		case 0:
			EnginePower = 10;
			break;
		case 1:
			EnginePower = 100;
			break;
		case 2:
			EnginePower = 225;
			break;
		case 3:
			EnginePower = 500;
			break;
		case 4:
			EnginePower = 700;
			break;
		case 5:
			EnginePower = 1000;
			break;
		}
	}
	
	void Explode(){
		GameObject bomb = (GameObject) Instantiate(ExplosionPrefab, 
		                                           transform.position, 
		                                           Quaternion.identity);
		bomb.transform.parent = transform.parent.parent;
		bomb.transform.localScale = new Vector3 (1,1,1);
		Attack bombAttack = bomb.GetComponent<Attack> ();
		bombAttack.Strength = Strength;
		GameObject.Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
		if (LevelGlobals.Paused)
			return;
		float timeElapsed = Time.deltaTime;
		EngineFuel -= timeElapsed;
		if (EngineFuel > 0) {
			LevelGlobals.Power += EnginePower * timeElapsed;
		} else {
			LevelGlobals.Power += EnginePower * (timeElapsed + EngineFuel);
			Explode();
		}
	}
}
