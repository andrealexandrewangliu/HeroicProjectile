using UnityEngine;
using System.Collections;

public class CutsceneTextbox : MonoBehaviour {
	public GameObject BGColor;
	public GameObject BGBorder;
	public UnityEngine.UI.Text TextSimple;
	public UnityEngine.UI.Text TextTitleName;
	public UnityEngine.UI.Text TextTitleText;

	public void WriteText(string text){
		Open ();
		TextSimple.gameObject.SetActive (true);
		TextTitleName.gameObject.SetActive (false);
		TextTitleText.gameObject.SetActive (false);
		TextSimple.text = text;
	}
	
	public void WriteText(string title, string text){
		Open ();
		TextSimple.gameObject.SetActive (false);
		TextTitleName.gameObject.SetActive (true);
		TextTitleText.gameObject.SetActive (true);
		TextTitleName.text = title;
		TextTitleText.text = text;
	}

	public void Open(){
		BGColor.SetActive (true);
		BGBorder.SetActive (true);
	}

	public void Close(){
		TextSimple.gameObject.SetActive (false);
		TextTitleName.gameObject.SetActive (false);
		TextTitleText.gameObject.SetActive (false);
		BGColor.SetActive (false);
		BGBorder.SetActive (false);
	}
}
