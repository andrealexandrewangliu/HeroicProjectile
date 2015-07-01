using UnityEngine;
using System.Collections;

public class UITextToggleColor : MonoBehaviour {
	private Color Basic;
	public Color ToggleColor;
	public bool ToggleAtInit = false;

	// Use this for initialization
	void Start () {
		Basic = GetComponent<UnityEngine.UI.Text> ().color;
		if (ToggleAtInit) {
			GetComponent<UnityEngine.UI.Text> ().color = ToggleColor;
		}
	}

	public void Toggle(){
		if (GetComponent<UnityEngine.UI.Text> ().color == Basic) {
			GetComponent<UnityEngine.UI.Text> ().color = ToggleColor;
		} 
		else {
			GetComponent<UnityEngine.UI.Text> ().color = Basic;
		}
	}
}
