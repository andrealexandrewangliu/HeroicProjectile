using UnityEngine;
using System.Collections;

public class UpgradeItem : MonoBehaviour {
	public UnityEngine.UI.Text NameBox;
	public UnityEngine.UI.Text DescriptionBox;
	public UnityEngine.UI.Text PriceBox;
	public GameObject[] LVBox = new GameObject[5];
	public UnityEngine.UI.Image ImageBox;
	public UpgradeList UpgradeItemManager;
	public int ItemNumber;
	private int PriceData;

	public void SetLevel(int lv){
		if (lv > LVBox.Length) {
			lv = LVBox.Length;
		}
		for (int i = 0; i < lv; i++){
			LVBox[i].SetActive(true);
		}
		for (int i = lv; i < LVBox.Length; i++){
			LVBox[i].SetActive(false);
		}
	}
	
	public void SetTitle(string title){
		NameBox.text = title;
	}
	
	public void SetDescription(string des){
		DescriptionBox.text = des;
	}
	
	public void SetPrice(int price){
		PriceData = price;
		if (PriceData > 0) {
			PriceBox.text = PriceData.ToString ();
		} else {
			PriceBox.text = "MAX";
			GetComponent<UnityEngine.UI.Button>().interactable = false;
		}
	}

	public void SetAvailable(){
		UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button> ();
		if (PriceData > BaseGlobalStats.Money || PriceData <= 0) {
			button.interactable = false;
			DescriptionBox.color = button.colors.disabledColor;
			PriceBox.color = button.colors.disabledColor;
		} else {
			button.interactable = true;
			DescriptionBox.color = button.colors.normalColor;
			PriceBox.color = button.colors.normalColor;
		}
	}

	public void ActionButton(){
		UpgradeItemManager.Upgrade (ItemNumber);
	}

	void LateUpdate(){
		SetAvailable ();
	}
}
