using UnityEngine;
using System.Collections;

public class ActionButtonUpdate : MonoBehaviour {
	public static bool ToggleParty = true; 
	public GameObject ToggleButton;
	public GameObject[] Button = new GameObject[4];

	void Start(){
		if (!ToggleParty) {

		}
		UpdateButtons ();
	}
	public void TogglePartyBoolean(){
		ToggleParty = !ToggleParty;
	}

	public void UpdateButtons(){
		if (ToggleParty) {
			for(int i = 0; i < PartyMember.CurrentParty.Count; i++){
				GameObject imgObj = Button[i].transform.GetChild(0).gameObject;
				imgObj.SetActive(true);
				UnityEngine.UI.Image img = imgObj.GetComponent<UnityEngine.UI.Image>();
				img.sprite =((GameObject) PartyMember.CurrentParty[i]).GetComponent<SpriteRenderer>().sprite;
				Button[i].GetComponent<UnityEngine.UI.Button>().interactable = true;
			}
			for(int i = PartyMember.CurrentParty.Count; i < 4; i++){
				GameObject imgObj = Button[i].transform.GetChild(0).gameObject;
				imgObj.SetActive(false);
				Button[i].GetComponent<UnityEngine.UI.Button>().interactable = false;
			}
		}
		else {

		}
	}
	
	private void UseParty(int i){
		GameObject member = (GameObject) PartyMember.CurrentParty[i];
		member.GetComponent<PartyMember> ().UseAbility ();
		UpdateButtons ();
	}

	private void UseItem(int i){
	}

	public void ActionClick(int i){
		if (ToggleParty) {
			UseParty(i);
		}
		else{
			UseItem(i);
		}
	}
}
