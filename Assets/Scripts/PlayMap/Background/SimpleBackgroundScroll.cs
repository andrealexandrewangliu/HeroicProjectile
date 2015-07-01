using UnityEngine;
using System.Collections;

public class SimpleBackgroundScroll : MonoBehaviour {
	public float ScrollMaximumSpeed = 5000.0f;
	public float ScrollMinimumSpeed = 1.0f;
	public float NormalSize = 23.0f;
	public float ScrollSpeed = 10;
	public float Border = 18;
	public GameObject[] Backgrounds = new GameObject[2];
	private int HeadBGIndex = 0;

	// Update is called once per frame
	void Update () {
		if (LevelGlobals.Paused)
			return;
		float speed = ScrollSpeed;
		if (speed > ScrollMaximumSpeed) {
			speed = ScrollMaximumSpeed;
		} 
		else if (speed < ScrollMinimumSpeed) {
			speed = ScrollMinimumSpeed;
		}
		speed *= Time.deltaTime;
		foreach (GameObject bg in Backgrounds) {
			//Debug.Log(bg.name + " Position = " + bg.transform.localPosition.y + " - (" + ScrollSpeed + " * " + Time.deltaTime + ") = " + (bg.transform.localPosition.y - (ScrollSpeed * Time.deltaTime)));
			if (bg.activeSelf)
				bg.transform.localPosition += new Vector3(0, - (speed * Time.deltaTime),0 );
		}

		while (Backgrounds[HeadBGIndex].transform.localPosition.y < -Border) {
			GameObject tail;

			if (HeadBGIndex <= 0){
				tail = Backgrounds[Backgrounds.Length - 1];
			}
			else{
				tail = Backgrounds[HeadBGIndex - 1];
			}

			
			Backgrounds[HeadBGIndex].transform.localPosition = new Vector3(tail.transform.localPosition.x, 
			                                                               tail.transform.localPosition.y + NormalSize,
			                                                               tail.transform.localPosition.z);
			
			HeadBGIndex++;
			if (HeadBGIndex >= Backgrounds.Length){
				HeadBGIndex = 0;
			}
		}
	}
}
