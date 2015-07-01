using UnityEngine;
using System.Collections;

public class TrailEffect : MonoBehaviour {
	public Transform Parent;
	public GameObject ProjectilePrefab;
	public float FireRate = 1;
	public float Speed = 1;
	public Vector2 Direction = new Vector2(0,-1).normalized;
	private float ShotDelaying = 0;
	
	public float ShotDelay{
		get{
			return 1.0f / FireRate;
		}
	}
	
	// Use this for initialization
	void Start () {
		ShotDelaying = ShotDelay;
	}
	
	private void Shoot(){
		Vector2 origin = transform.position;
		GameObject trail = (GameObject)Instantiate (ProjectilePrefab, 
		                                            transform.position, 
		                                            Quaternion.identity);

		trail.GetComponent<MoveToDestination2D> ().Speed = Speed;
		trail.GetComponent<MoveToDestination2D> ().Destination2D = origin + (Direction * 1000 * LevelGlobals.StageScale);

		trail.transform.parent = Parent;
		trail.transform.localScale = new Vector3 (1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelGlobals.Paused)
			return;
		while (ShotDelaying <= 0) {
			ShotDelaying += ShotDelay;
			Shoot();
		}
		ShotDelaying -= Time.deltaTime;
	}
}
