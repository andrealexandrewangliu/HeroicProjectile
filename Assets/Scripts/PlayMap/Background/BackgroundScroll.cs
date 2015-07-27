using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {
	private const float ScrollMaximumSpeed = 8000.0f;
	public int StageOffset = -1;
	public float NormalSize = 6.4f;
	public float EndSize = 2.080333f;
	public float ScrollSpeed = 10;
	public float Border = 5;
	public GameObject[] Backgrounds = new GameObject[2];
	public GameObject EndBackground;
	public bool looping = true;
	public Sprite [] BackgroundImages;
	public Sprite [] BackgroundEndImages;
	private int HeadBGIndex = 0;
	private bool Transition = false;
	private bool EndIsTail = false;
	private bool IsInit = false;

	public int NextBGIMGIndex{
		get {
			return this.StageOffset + LevelGlobals.Stage;
		}
	}
	
	public void ForceInit(){
		IsInit = false;
		Init ();
	}

	public void Init(){
		if (!IsInit) {
			if (NextBGIMGIndex >= 0 && NextBGIMGIndex < BackgroundImages.Length) {
				foreach (GameObject bg in Backgrounds) {
					bg.GetComponent<SpriteRenderer> ().sprite = BackgroundImages [NextBGIMGIndex];
				}
				EndBackground.GetComponent<SpriteRenderer> ().sprite = BackgroundEndImages [NextBGIMGIndex];
			} else {
				looping = false;
				foreach (GameObject bg in Backgrounds) {
					bg.GetComponent<SpriteRenderer> ().sprite = BackgroundImages [0];
				}
				EndBackground.GetComponent<SpriteRenderer> ().sprite = BackgroundEndImages [0];
				//gameObject.SetActive(false);
			}
		}
	}

	// Use this for initialization
	void Start () {
		Init ();
	}

	public void EndTransition(){
		if (NextBGIMGIndex >= BackgroundImages.Length) {
			looping = false;
		}
		else if (!Transition && looping) {
			Transition = true;
			EndIsTail = true;
			float lastImageOffset = NormalSize;
			GameObject tail;
			if (HeadBGIndex <= 0) {
				tail = Backgrounds [Backgrounds.Length - 1];
			} else {
				tail = Backgrounds [HeadBGIndex - 1];
			}
		
			EndBackground.SetActive(true);
			EndBackground.transform.localPosition = new Vector3 (tail.transform.localPosition.x, 
			                                                tail.transform.localPosition.y + lastImageOffset + EndSize,
		                                                    tail.transform.localPosition.z);
			//Debug.Log(this.StageOffset + " + " + LevelGlobals.Stage + " = " + NextBGIMGIndex);
			EndBackground.GetComponent<SpriteRenderer>().sprite = BackgroundEndImages[NextBGIMGIndex];
		}
	}

	public void UpdateLooping(){
		if (NextBGIMGIndex >= 0 && NextBGIMGIndex < BackgroundImages.Length) {
			foreach (GameObject bg in Backgrounds){
				bg.SetActive(true);
			}
			looping = true;
		}
		else
			looping = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelGlobals.Paused)
			return;

		float speed = ScrollSpeed * Time.deltaTime;
//		if (speed > ScrollMaximumSpeed)
//			speed = ScrollMaximumSpeed;
		foreach (GameObject bg in Backgrounds) {
			//Debug.Log(bg.name + " Position = " + bg.transform.localPosition.y + " - (" + ScrollSpeed + " * " + Time.deltaTime + ") = " + (bg.transform.localPosition.y - (ScrollSpeed * Time.deltaTime)));
			if (bg.activeSelf)
				bg.transform.localPosition += new Vector3(0, - (speed * Time.deltaTime),0 );
		}

		if (Transition) {
			EndBackground.transform.localPosition += new Vector3(0, - (speed * Time.deltaTime), 0);
			if (EndBackground.transform.localPosition.y < -(EndSize + Border)){
				EndBackground.SetActive(false);
				Transition = false;
			}
		}
		while (Backgrounds[HeadBGIndex].transform.localPosition.y < -(NormalSize + Border)) {
			if (looping){
				float lastImageOffset = NormalSize;
				GameObject tail;
				if (EndIsTail){
					lastImageOffset = EndSize;
					EndIsTail = false;
					tail = EndBackground;
				}
				else{
					if (HeadBGIndex <= 0){
						tail = Backgrounds[Backgrounds.Length - 1];
					}
					else{
						tail = Backgrounds[HeadBGIndex - 1];
					}
				}
				
				Backgrounds[HeadBGIndex].transform.localPosition = new Vector3(tail.transform.localPosition.x, 
				                                                          tail.transform.localPosition.y + lastImageOffset + NormalSize,
				                                                          tail.transform.localPosition.z);
				Backgrounds[HeadBGIndex].GetComponent<SpriteRenderer>().sprite = BackgroundImages[NextBGIMGIndex];
			
				HeadBGIndex++;
				if (HeadBGIndex >= Backgrounds.Length){
					HeadBGIndex = 0;
				}
			}
			else{
				Backgrounds[HeadBGIndex].SetActive (false);
				HeadBGIndex++;
				if (HeadBGIndex >= Backgrounds.Length){
					HeadBGIndex = 0;
				}
				break;
			}
		}
	}
}
