using UnityEngine;
using System.Collections;

public class ActorManager : MonoBehaviour {
	// Sizes: 13 x 13 tiles
	// -4 to 4 x -4 to 4 space
	// Offset = abs(-4) + abs(4) / (12 * 2)
	private const float OffsetX = 8.0f / 26.0f;
	private const float OffsetY = 8.0f / 26.0f;
	private const float MinCornerX = -4.0f;
	private const float MinCornerY = -4.0f;
	public GameObject[] Actors;
	public Vector2[] ActorsStarts;
	public AudioClip[] SoundEffects = new AudioClip[1];

	public void PlaySE(int i){
		AudioSource.PlayClipAtPoint (SoundEffects [i], this.transform.position);
	}
	
	public static Vector2 Coordinate(int x, int y){
		return Coordinate ((float)x, (float)y);
	}
	
	private static Vector2 Coordinate(float x, float y){
		return new Vector2 (MinCornerX + OffsetX + 2 * (OffsetX * x),
		                   MinCornerY + OffsetY + 2 * (OffsetY * y));
	}
	
	private static Vector3 Coordinate3(float x, float y){
		return new Vector3 (MinCornerX + OffsetX + 2 * (OffsetX * x),
		                    MinCornerY + OffsetY + 2 * (OffsetY * y), 5);
	}

	public void WarpAllActors(){
		foreach (GameObject actor in Actors) {
			actor.GetComponent<CutsceneMovetoDestination2D> ().WarpToDestination ();
		}
	}
	
	public void NoEmoteAllActors(){
		foreach (GameObject actor in Actors) {
			actor.GetComponent<CutsceneActorMovement> ().HideEmote();
		}
	}
	
	public void SetActorSpeed(int index, float speed){
		Actors [index].GetComponent<MoveToDestination2D> ().Speed = speed;
	}
	public void TurnActor(int index, CutsceneActorMovement.DirectionEnum direction){
		Actors [index].GetComponent<CutsceneActorMovement> ().SpriteDirection = direction;
	}
	public void JumpActor(int index){
		Actors [index].GetComponent<CutsceneActorMovement> ().Jump ();
	}
	public void MoveActor(int index, int x, int y){
		Actors [index].GetComponent<MoveToDestination2D> ().Destination2D = Coordinate (x, y);
	}
	public void EmoteActor(int index, CutsceneActorMovement.Emote emote){
		Actors [index].GetComponent<CutsceneActorMovement> ().PlayEmote(emote);
	}
	public void NoEmoteActor(int index){
		Actors [index].GetComponent<CutsceneActorMovement> ().HideEmote();
	}

	// Use this for initialization
	void Start () {
		for (int i = 0; i < ActorsStarts.Length; i++){
			Vector3 start = Coordinate3(ActorsStarts[i].x, ActorsStarts[i].y);
			Actors[i].transform.localPosition = start;
			Actors[i].GetComponent<MoveToDestination2D>().Destination2D = new Vector2(start.x, start.y);
			Actors[i].GetComponent<MoveToDestination2D>().Active = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
