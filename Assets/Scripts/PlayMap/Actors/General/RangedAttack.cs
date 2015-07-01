using UnityEngine;
using System.Collections;

public class RangedAttack : MonoBehaviour {
	public GameObject ProjectilePrefab;
	public float FireRate = 1;
	public float Speed = 1;
	public float Strength = 1;
	public int Ammo = -1;
	protected float ShotDelaying = 0;
	protected bool Friendly = false;
	protected float EndBorderY, EndBorderYOpposite;
	protected float EndBorderXMinus, EndBorderXPlus;

	public float ShotDelay{
		get{
			return 1.0f / FireRate;
		}
	}

	// Use this for initialization
	void Start () {
		ShotDelaying = ShotDelay;
		if (tag == "Ally") {
			Friendly = true;
		} else if (tag == "Ally_Wander") {
			Friendly = true;
		} else if (tag == "Ally_Kicked") {
			Friendly = true;
		} else if (tag == "Ally_Projectile") {
			Friendly = true;
		} else {
			Friendly = false;
		}

		Vector3 bPlus = LevelGlobals.LocalGlobals.EnemySpawner.borderPlus.transform.position;
		Vector3 bMinus = LevelGlobals.LocalGlobals.EnemySpawner.borderMinus.transform.position;
		float tolerance = 3 * LevelGlobals.StageScale;
		if (Friendly) {
			EndBorderY = bPlus.y + tolerance;
			EndBorderYOpposite = bMinus.y - tolerance;
		} else {
			EndBorderY = bMinus.y - tolerance;
			EndBorderYOpposite = bPlus.y + tolerance;
		}
		EndBorderXMinus = LevelGlobals.LocalGlobals.EnemySpawner.borderMinus.transform.position.x - tolerance;
		EndBorderXPlus = LevelGlobals.LocalGlobals.EnemySpawner.borderPlus.transform.position.x + tolerance;
	}

	protected virtual void Shoot(){
		//Vector2 bottom = new Vector2(transform.position.x, bPlus.y);
		GameObject shoot = (GameObject)Instantiate (ProjectilePrefab, 
		                                            transform.position, 
		                                            Quaternion.identity);
		shoot.GetComponent<MoveToDestination2D> ().Speed = Speed;
		if (Friendly) {
			Vector3 bPlus = LevelGlobals.LocalGlobals.EnemySpawner.borderPlus.transform.position;
			shoot.GetComponent<MoveToDestination2D> ().Destination2D = new Vector2 (transform.position.x, bPlus.y + (2 * LevelGlobals.StageScale));
		} else {
			Vector3 bMinus = LevelGlobals.LocalGlobals.EnemySpawner.borderMinus.transform.position;
			shoot.GetComponent<MoveToDestination2D> ().Destination2D = new Vector2 (transform.position.x, bMinus.y + (2 * LevelGlobals.StageScale));
		}
		Attack normalAttack = shoot.GetComponent<Attack> ();
		if (normalAttack != null) {
			normalAttack.Strength = Strength;
		}
		BombAttack bombAttack = shoot.GetComponent<BombAttack> ();
		if (bombAttack != null) {
			bombAttack.Strength = Strength;
		}
		shoot.transform.parent = transform.parent;
		shoot.transform.localScale = new Vector3 (1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelGlobals.Paused)
			return;
		while (ShotDelaying <= 0) {
			ShotDelaying += ShotDelay;
			if (Ammo != 0){
				Shoot();
				if (Ammo > 0)
					Ammo--;
			}
		}
		ShotDelaying -= Time.deltaTime;
	}
}
