using UnityEngine;
using System.Collections;

public class RotateOnce : MonoBehaviour {
	public Vector3 rotation;
	// Use this for initialization
	void Start () {
		transform.localEulerAngles = rotation;
	}
}
