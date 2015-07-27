using UnityEngine;
using System.Collections;

public class ScreenResolution : MonoBehaviour {
	public int Width;
	public int Height;
	public bool Fullscreen = true;

	// Use this for initialization
	void Start () {
		Screen.SetResolution (Width, Height, Fullscreen);
	}
}
