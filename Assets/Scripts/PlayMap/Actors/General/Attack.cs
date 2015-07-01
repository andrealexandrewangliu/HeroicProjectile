using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attack : MonoBehaviour {
	public float Strength = 1;
	public bool DestroyAfterHit = true;
	public float DamageIntervalDelay = 0.2f;
	public Animator SelfImpactAnimation;
	private float DamageIntervalDelaying = 0;
	private bool Friendly = false;
	private Animator AttackAnimator;

	private List<Collider2D> colliders = new List<Collider2D>();

	void Start () {
		Friendly = (tag == "Ally_Projectile");
		AttackAnimator = GetComponent<Animator> ();
	}


	// Update is called once per frame
	void Update () {
		if (!LevelGlobals.Paused) {
			if (AttackAnimator != null){
				AttackAnimator.enabled = true;
			}
			bool hit = false;
			if (DamageIntervalDelaying > 0) {
				DamageIntervalDelaying -= Time.deltaTime;
			}
			if (DamageIntervalDelaying <= 0) {
				foreach (var coll in colliders) {
					if (coll.gameObject.tag == "Enemy") {
						coll.gameObject.GetComponent<PlayerTargetable> ().Damage (Strength);
						coll.gameObject.GetComponent<Animator> ().Play ("NormalDamage");
						hit = true;
					} else if (coll.gameObject.tag == "Ally") {
						coll.gameObject.GetComponent<PartyMember> ().KillMember ();
						hit = true;
					} else if (coll.gameObject.tag == "Player") {
						LevelGlobals.PowerDamage (Strength * 100);
						coll.gameObject.GetComponent<Animator> ().Play ("NormalDamage");
				
						hit = true;
					}

				}
				if (hit) {
					if (SelfImpactAnimation != null) {
						SelfImpactAnimation.Play ("MeleeAttack");
					}
					if (DestroyAfterHit) {
						GameObject.Destroy (this.gameObject);
						//break;
					}
				}
				DamageIntervalDelaying += DamageIntervalDelay;
			}
			if (DamageIntervalDelaying < 0) {
				DamageIntervalDelaying = 0;
			}
		}
		else {
			if (AttackAnimator != null){
				AttackAnimator.enabled = false;
			}
		}
	}

	void OnTriggerStay2D(Collider2D coll) {
		//Debug.Log(name);
		if (Friendly) {
			if (coll.gameObject.tag == "Enemy") {
				PlayerTargetable target = coll.gameObject.GetComponent<PlayerTargetable>();
				if (target != null){
					colliders.Add(coll);
				}
			}
		} 
		else {
			if (coll.gameObject.tag == "Ally") {
				colliders.Add(coll);
			}
			else if (coll.gameObject.tag == "Player") {
				colliders.Add(coll);
			}
		}
	}

	void LateUpdate () {
		colliders.Clear ();
	}

}
