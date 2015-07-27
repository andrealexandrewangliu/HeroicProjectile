using UnityEngine;
using System.Collections;
using System;

public class UpgradeList : MonoBehaviour {
	public UpgradeItemData[] UpgradeItems = new UpgradeItemData[25];
	public float [] BasePrices = new float[5];
	public GameObject MList;
	public GameObject ItemPrefab;
	public float ItemSize = 70;

	public int Price(int item){
		if (UpgradeItems [item].LV >= BasePrices.Length) {
			return -1;
		} else {
			return (int)(BasePrices [UpgradeItems [item].LV] * UpgradeItems [item].PriceFactor);
		}
	}

	public void SetLV(){
		UpgradeItems[0].LV = (int) BaseGlobalStats.PlayerSpeedLvl;
		UpgradeItems[1].LV = (int) BaseGlobalStats.PlayerPowerLvl;
		UpgradeItems[2].LV = (int) BaseGlobalStats.PowerLossRatioLvl;
		UpgradeItems[3].LV = (int) BaseGlobalStats.PowerDefenseLvl;
		UpgradeItems[4].LV = (int) BaseGlobalStats.MoneyRatioLvl;
		UpgradeItems[5].LV = BaseGlobalStats.GuardSpawnRateLvl;
		UpgradeItems[6].LV = BaseGlobalStats.GuardLvl;
		UpgradeItems[7].LV = BaseGlobalStats.ImoutoSpawnRateLvl;
		UpgradeItems[8].LV = BaseGlobalStats.ImoutoLvl;
		UpgradeItems[9].LV = BaseGlobalStats.ElfSpawnRateLvl;
		UpgradeItems[10].LV = BaseGlobalStats.ElfLvl;
		UpgradeItems[11].LV = BaseGlobalStats.OrcSpawnRateLvl;
		UpgradeItems[12].LV = BaseGlobalStats.OrcLvl;
		UpgradeItems[13].LV = BaseGlobalStats.DwarfSpawnRateLvl;
		UpgradeItems[14].LV = BaseGlobalStats.DwarfLvl;
		UpgradeItems[15].LV = BaseGlobalStats.SuccubusSpawnRateLvl;
		UpgradeItems[16].LV = BaseGlobalStats.SuccubusLvl;
		UpgradeItems[17].LV = BaseGlobalStats.PriestSpawnRateLvl;
		UpgradeItems[18].LV = BaseGlobalStats.PriestLvl;
		UpgradeItems[19].LV = BaseGlobalStats.PirateSpawnRateLvl;
		UpgradeItems[20].LV = BaseGlobalStats.PirateLvl;
		UpgradeItems[21].LV = BaseGlobalStats.MageSpawnRateLvl;
		UpgradeItems[22].LV = BaseGlobalStats.MageLvl;
		UpgradeItems[23].LV = BaseGlobalStats.WarlockSpawnRateLvl;
		UpgradeItems[24].LV = BaseGlobalStats.WarlockLvl;
	}

	public void Init(){
		SetLV ();
		int maxIndex;
		maxIndex = 5 + BaseGlobalStats.MaxLevel * 2;
		if (maxIndex > UpgradeItems.Length)
			maxIndex = UpgradeItems.Length;
		MList.GetComponent<RectTransform> ().sizeDelta =
			new Vector2 (MList.GetComponent<RectTransform> ().sizeDelta.x,
			             ItemSize * (5 + BaseGlobalStats.MaxLevel * 2));
		
		for (int i = 0; i < maxIndex; i++) {
			float displacement = -((ItemSize / 2) + (i * ItemSize));
			GameObject item = (GameObject)Instantiate (ItemPrefab, 
			                                           MList.transform.position, 
			                                           Quaternion.identity);
			item.transform.SetParent(MList.transform);
			UpgradeItem itemdata = item.GetComponent<UpgradeItem>();
			itemdata.ImageBox.sprite = UpgradeItems[i].Image;
			itemdata.SetLevel(UpgradeItems[i].LV);
			itemdata.SetPrice(Price(i));
			itemdata.SetTitle(UpgradeItems[i].Name);
			itemdata.SetDescription(UpgradeItems[i].Description);
			itemdata.UpgradeItemManager = this;
			itemdata.ItemNumber = i;
			item.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, displacement);
			item.GetComponent<RectTransform>().sizeDelta = new Vector2(
				MList.GetComponent<RectTransform>().sizeDelta.x, 
				70);
		}
	}

	// Use this for initialization
	void Start () {
		Init ();
	}

	public void UpdateItems(){
		int maxIndex;
		try{
			maxIndex = 5 + BaseGlobalStats.MaxLevel * 2;
			if (maxIndex > UpgradeItems.Length)
				maxIndex = UpgradeItems.Length;
		}
		catch{
			maxIndex = 7;
			if (maxIndex > UpgradeItems.Length)
				maxIndex = UpgradeItems.Length;
		}
		for (int i = 0; i < maxIndex; i++) {
			GameObject item = MList.transform.GetChild(i).gameObject;
			UpgradeItem itemdata = item.GetComponent<UpgradeItem>();
			itemdata.SetPrice(Price(i));
			itemdata.SetLevel(UpgradeItems[i].LV);
		}
	}


	public void Upgrade(int index){
		BaseGlobalStats.Money -= Price (index);
		UpgradeItems [index].LV++;
		switch (index) {
		case 0:
			BaseGlobalStats.PlayerSpeedLvl+=1;
			break;
		case 1:
			BaseGlobalStats.PlayerPowerLvl+=1;
			break;
		case 2:
			BaseGlobalStats.PowerLossRatioLvl+=1;
			break;
		case 3:
			BaseGlobalStats.PowerDefenseLvl+=1;
			break;
		case 4:
			BaseGlobalStats.MoneyRatioLvl+=1;
			break;
		case 5:
			BaseGlobalStats.GuardSpawnRateLvl+=1;
			break;
		case 6:
			BaseGlobalStats.GuardLvl+=1;
			break;
		case 7:
			BaseGlobalStats.ImoutoSpawnRateLvl+=1;
			break;
		case 8:
			BaseGlobalStats.ImoutoLvl+=1;
			break;
		case 9:
			BaseGlobalStats.ElfSpawnRateLvl+=1;
			break;
		case 10:
			BaseGlobalStats.ElfLvl+=1;
			break;
		case 11:
			BaseGlobalStats.OrcSpawnRateLvl+=1;
			break;
		case 12:
			BaseGlobalStats.OrcLvl+=1;
			break;
		case 13:
			BaseGlobalStats.DwarfSpawnRateLvl+=1;
			break;
		case 14:
			BaseGlobalStats.DwarfLvl+=1;
			break;
		case 15:
			BaseGlobalStats.SuccubusSpawnRateLvl+=1;
			break;
		case 16:
			BaseGlobalStats.SuccubusLvl+=1;
			break;
		case 17:
			BaseGlobalStats.PriestSpawnRateLvl+=1;
			break;
		case 18:
			BaseGlobalStats.PriestLvl+=1;
			break;
		case 19:
			BaseGlobalStats.PirateSpawnRateLvl+=1;
			break;
		case 20:
			BaseGlobalStats.PirateLvl+=1;
			break;
		case 21:
			BaseGlobalStats.MageSpawnRateLvl+=1;
			break;
		case 22:
			BaseGlobalStats.MageLvl+=1;
			break;
		case 23:
			BaseGlobalStats.WarlockSpawnRateLvl+=1;
			break;
		case 24:
			BaseGlobalStats.WarlockLvl+=1;
			break;
		}
		BaseGlobalStats.SavePersistentData ();
		UpdateItems ();

	}
}

[Serializable]
public class UpgradeItemData {
	public Sprite Image;
	public string Name;
	public string Description;
	public float PriceFactor;
	public int LV;
}