using UnityEngine;
using System.Collections;

public class WarlockAI : MonoBehaviour {
	private const float ChargeTime = 8f;
	private const float CannonTime = ChargeTime + 1.0f;
	private const float RetreatTime = CannonTime + 1.0f;
	public GameObject WarlockCharge;
	public GameObject WarlockSpark;
	public float ElapsedTime = 5;
	private Vector2 RetreatPoint;

	// Use this for initialization
	void Start () {
		RetreatPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!LevelGlobals.Paused) {
			ElapsedTime += Time.deltaTime;
			if (ElapsedTime >= ChargeTime) {
				GetComponent<MoveToDestination2D> ().enabled = false;
				WarlockCharge.SetActive (true);
			}

			if (ElapsedTime >= CannonTime) {
				WarlockSpark.SetActive (true);
			}

			if (ElapsedTime >= RetreatTime) {
				GetComponent<MoveToDestination2D> ().enabled = true;
				GetComponent<MoveToDestination2D> ().Destination2D = RetreatPoint;
				enabled = false;
			}
		}
	}
}
