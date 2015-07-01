using UnityEngine;
using System.Collections;

public class BombAttack : MonoBehaviour {
	public GameObject ExplosionPrefab;
	public float Strength = 1;
	private bool Friendly = false;
	public float ExploadIn = 2;
	
	void Start () {
		Friendly = (tag == "Ally_Projectile");
	}

	void Explode(){
		GameObject bomb = (GameObject) Instantiate(ExplosionPrefab, 
		                                           transform.position, 
		                                           Quaternion.identity);
		bomb.transform.parent = transform.parent;
		bomb.transform.localScale = new Vector3 (1,1,1);
		Attack bombAttack = bomb.GetComponent<Attack> ();
		bombAttack.Strength = Strength;
		GameObject.Destroy (gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D coll) {
		//Debug.Log(name);
		if (Friendly) {
			if (coll.gameObject.tag == "Enemy") {
				PlayerTargetable target = coll.gameObject.GetComponent<PlayerTargetable>();
				if (target != null){
					Explode();
				}
			}
		} 
		else {
			if (coll.gameObject.tag == "Ally") {
				Explode();
			}
			else if (coll.gameObject.tag == "Player") {
				Explode();
			}
		}
	}

	void Update(){
		if (LevelGlobals.Paused)
			return;
		if (ExploadIn > 0) {
			ExploadIn -= Time.deltaTime;
			if (ExploadIn <= 0){
				Explode();
			}
		}
	}
}
