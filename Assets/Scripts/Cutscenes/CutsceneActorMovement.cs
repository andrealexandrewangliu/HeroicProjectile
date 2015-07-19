using UnityEngine;
using System.Collections;

public class CutsceneActorMovement : MonoBehaviour {
	public float MoveIndex = 0;
	public Sprite [] Up = new Sprite[3];
	public Sprite [] Down = new Sprite[3];
	public Sprite [] Left = new Sprite[3];
	public Sprite [] Right = new Sprite[3];
	public DirectionEnum SpriteDirection = DirectionEnum.Down;
	public bool InactiveWhenStop = true;
	public PlayEmote EmotePlayer;
	private SpriteRenderer SRenderer;
	private Animator AnimatorController;
	private MoveToDestination2D Mover;
	private float JumpOffset = 0;
	private int JumpDirection = 0;
	private const float Offset = 8.0f / 26.0f;
	
	public enum DirectionEnum{
		Up,
		Down,
		Left,
		Right
	};
	
	public enum Emote{
		Suprised,
		Sleep,
		Idea,
		Silence,
		Frustration,
		SweatDrop,
		Angry,
		Love,
		Happy,
		Question
	};

	public void Jump(){
		JumpDirection = 1;
	}

	public void HideEmote(){
		try{
			EmotePlayer.NoEmote ();
		}
		catch(UnityException e){
		}
	}

	public void PlayEmote(Emote emoteselect){
		switch (emoteselect) {
		case Emote.Suprised:
			EmotePlayer.Suprised ();
			break;
		case Emote.Sleep:
			EmotePlayer.Sleep ();
			break;
		case Emote.Idea:
			EmotePlayer.Idea ();
			break;
		case Emote.Silence:
			EmotePlayer.Silence ();
			break;
		case Emote.Frustration:
			EmotePlayer.Frustration ();
			break;
		case Emote.SweatDrop:
			EmotePlayer.SweatDrop ();
			break;
		case Emote.Angry:
			EmotePlayer.Angry ();
			break;
		case Emote.Love:
			EmotePlayer.Love ();
			break;
		case Emote.Happy:
			EmotePlayer.Happy ();
			break;
		case Emote.Question:
			EmotePlayer.Question ();
			break;
		}
	}

	// Use this for initialization
	void Start () {
		EmotePlayer = transform.FindChild ("Emote").gameObject.GetComponent<PlayEmote> ();
		SRenderer = GetComponent<SpriteRenderer>();
		AnimatorController = GetComponent<Animator>();
		Mover = GetComponent<MoveToDestination2D>();
	}
	
	
	// Update is called once per frame
	void Update () {
		int mindex = (int)Mathf.Round(MoveIndex);
		if (!Mover.Active && InactiveWhenStop) {
			AnimatorController.Play("Idle");
			mindex = 0;
		}
		else{
			AnimatorController.Play("Move");
			if (mindex < 0)
				mindex = 2;
		}

		switch (SpriteDirection){
		case DirectionEnum.Up:
			if (Up[mindex] != null)
				SRenderer.sprite = Up[mindex];
			break;
		case DirectionEnum.Down:
			if (Down[mindex] != null)
				SRenderer.sprite = Down[mindex];
			break;
		case DirectionEnum.Left:
			if (Left[mindex] != null)
				SRenderer.sprite = Left[mindex];
			break;
		case DirectionEnum.Right:
			if (Right[mindex] != null)
				SRenderer.sprite = Right[mindex];
			break;
		}

		if (JumpDirection > 0) {
			float finalOffset = JumpOffset;
			Vector3 pos = this.transform.localPosition;
			JumpOffset += Time.deltaTime * 10;
			finalOffset = JumpOffset - finalOffset;
			if (JumpOffset > 1){
				JumpDirection = -1;
				JumpOffset -= 1;
				finalOffset -= JumpOffset;
			}
			pos.y += finalOffset * Offset;
			this.transform.localPosition = pos;
		} 
		else if (JumpDirection < 0) {
			float finalOffset = JumpOffset;
			Vector3 pos = this.transform.localPosition;
			JumpOffset += Time.deltaTime * 10;
			if (JumpOffset > 1){
				JumpDirection = 0;
				JumpOffset = 0;
				finalOffset = 1 - finalOffset;
			}
			else{
				finalOffset = JumpOffset - finalOffset;
			}
			
			pos.y -= finalOffset * Offset;
			this.transform.localPosition = pos;
		}
	}
}
