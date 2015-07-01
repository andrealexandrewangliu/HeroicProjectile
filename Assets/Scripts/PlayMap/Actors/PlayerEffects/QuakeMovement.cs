using UnityEngine;
using System.Collections;

public class QuakeMovement : MonoBehaviour {
	public float Damage = 0;
	public float Intensity = 0.3f;
	public float Frequency = 0.1f;
	private float Delay = 0;
	private Daze DazeCondition;
	private LimitedMoveToDestination2D Mover;

	public bool QuakeMovementCondition{
		get{
			return ImoutoStickToPlayer.IsImoutoStuck && DazeCondition.enabled;
		}
	}

	// Use this for initialization
	void Start () {
		DazeCondition = GetComponent<Daze> ();
		Mover = GetComponent<LimitedMoveToDestination2D> ();
	}

	public void CheckQuakeCondition(){
		if (QuakeMovementCondition)
			enabled = true;
	}

	void MakeQuake(){
		Vector3 direction = new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),0).normalized;
		float jump = Random.Range (0.0f, 1.0f) * Intensity;
		transform.localPosition += direction * jump;
		LevelGlobals.PowerDamage (Damage);
		Mover.CorrectPosition ();

	}
	
	// Update is called once per frame
	void Update () {
		if (LevelGlobals.Paused)
			return;
		if (!QuakeMovementCondition) {
			enabled = false;
		} else {
			Delay += Time.deltaTime;
			while(Delay >= Frequency){
				Delay-= Frequency;
				MakeQuake ();
			}
		}
	}
}
