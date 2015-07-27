using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class BaseGlobalStats : MonoBehaviour {

	private static BaseGlobalStats SaveGlobalData = null;
	public SaveGlobalStats SaveData = null;


	// First Upgrades
	public static float PlayerSpeed{
		get{
			StaticInit();
			return 5 + (SaveGlobalData.SaveData.PlayerSpeedLvl * 2);
		}
	}
	public static float PlayerPower{
		get{
			StaticInit();
			return 2000 + (SaveGlobalData.SaveData.PlayerPowerLvl * 2000);
		}
	}
	public static float PowerLossRatio{
		get{
			StaticInit();
			return 0.3f - (SaveGlobalData.SaveData.PowerLossRatioLvl * 0.04f);
		}
	}
	public static float PowerDefense{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.PowerDefenseLvl * 0.02f;
		}
	}
	public static float MoneyRatio{
		get{
			StaticInit();
			return 1.0f + (SaveGlobalData.SaveData.MoneyRatioLvl * 0.2f);
		}
	}


	// First Upgrades
	public static float PlayerSpeedLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.PlayerSpeedLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.PlayerSpeedLvl = value;
		}
	}
	public static float PlayerPowerLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.PlayerPowerLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.PlayerPowerLvl = value;
		}
	}     // Masochism
	public static float PowerLossRatioLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.PowerLossRatioLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.PowerLossRatioLvl = value;
		}
	}   // Hair Gel
	public static float PowerDefenseLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.PowerDefenseLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.PowerDefenseLvl = value;
		}
	}     // Muscle
	public static float MoneyRatioLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.MoneyRatioLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.MoneyRatioLvl = value;
		}
	}   // Greed

	// Upgrades
	public static int GuardSpawnRateLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.GuardSpawnRateLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.GuardSpawnRateLvl = value;
		}
	}// Drafting
	public static int ElfSpawnRateLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.ElfSpawnRateLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.ElfSpawnRateLvl = value;
		}
	}       // Handsomeness
	public static int DwarfSpawnRateLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.DwarfSpawnRateLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.DwarfSpawnRateLvl = value;
		}
	}     // Investiment
	public static int PriestSpawnRateLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.PriestSpawnRateLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.PriestSpawnRateLvl = value;
		}
	}    // Faith
	public static int MageSpawnRateLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.MageSpawnRateLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.MageSpawnRateLvl = value;
		}
	}     // Grades

	public static int ImoutoSpawnRateLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.ImoutoSpawnRateLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.ImoutoSpawnRateLvl = value;
		}
	}    // Maturity
	public static int OrcSpawnRateLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.OrcSpawnRateLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.OrcSpawnRateLvl = value;
		}
	}       // Education
	public static int SuccubusSpawnRateLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.SuccubusSpawnRateLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.SuccubusSpawnRateLvl = value;
		}
	}  // Ikemen
	public static int PirateSpawnRateLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.PirateSpawnRateLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.PirateSpawnRateLvl = value;
		}
	}    // Pub Party
	public static int WarlockSpawnRateLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.WarlockSpawnRateLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.WarlockSpawnRateLvl = value;
		}
	}   // Spam
	
	public static int GuardLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.GuardLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.GuardLvl = value;
		}
	}             // Drill Trainning
	public static int ElfLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.ElfLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.ElfLvl = value;
		}
	}                // Rivalry
	public static int DwarfLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.DwarfLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.DwarfLvl = value;
		}
	}              // Mad Science
	public static int PriestLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.PriestLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.PriestLvl = value;
		}
	}             // Devotion
	public static int MageLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.MageLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.MageLvl = value;
		}
	}               // Cramming
	
	public static int ImoutoLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.ImoutoLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.ImoutoLvl = value;
		}
	}             // Childcare
	public static int OrcLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.OrcLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.OrcLvl = value;
		}
	}                // Wrestling
	public static int SuccubusLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.SuccubusLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.SuccubusLvl = value;
		}
	}           // Sixth Sense
	public static int PirateLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.PirateLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.PirateLvl = value;
		}
	}             // Arrr
	public static int WarlockLvl{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.WarlockLvl;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.WarlockLvl = value;
		}
	}            // Work Stress
	
	public static int Money{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.Money;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.Money = value;
		}
	}
	public static int Score{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.Score;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.Score = value;
		}
	}
	
	public static int MaxLevel{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.MaxLevel;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.MaxLevel = value;
		}
	}
	
	public static int StartLevel{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.StartLevel;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.StartLevel = value;
		}
	}
	
	public static bool Intro{
		get{
			StaticInit();
			return SaveGlobalData.SaveData.Intro;
		}
		set{
			StaticInit();
			SaveGlobalData.SaveData.Intro = value;
		}
	}

	public static void StaticInit(){
		if (SaveGlobalData == null) {
			GameObject.Find ("GameData").GetComponent<BaseGlobalStats> ().Init ();
		}
	}

	public void Init(){
		if (SaveGlobalData == null) {
			BaseGlobalStats.SaveGlobalData = this;
			Load ();
		} else if (SaveGlobalData != this) {
			GameObject.Destroy(gameObject);
		}
	}

	void Start(){
		Init ();
	}
	public static void SavePersistentData(){
		if (SaveGlobalData != null) {
			SaveGlobalData.Save();
		}
	}

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/HeroicProjectileSave.dat", FileMode.OpenOrCreate);

		bf.Serialize (file, SaveGlobalData.SaveData);
		file.Close ();
	}

	private void Load(){
		if (File.Exists (Application.persistentDataPath + "/HeroicProjectileSave.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/HeroicProjectileSave.dat", FileMode.Open);
			SaveData = (SaveGlobalStats)bf.Deserialize (file);
			file.Close ();
		} else {
			SaveData = new SaveGlobalStats();
		}
	}
}

[Serializable]
public class SaveGlobalStats{
	// First Upgrades
	public float PlayerSpeedLvl = 0;         // Gliding
	public float PlayerPowerLvl = 0;     // Masochism
	public float PowerLossRatioLvl = 0;   // Hair Gel
	public float PowerDefenseLvl = 0;     // Muscle
	public float MoneyRatioLvl = 0;
	
	// Upgrades
	public int GuardSpawnRateLvl = 0;     // Drafting
	public int ElfSpawnRateLvl = 0;       // Handsomeness
	public int DwarfSpawnRateLvl = 0;     // Investiment
	public int PriestSpawnRateLvl = 0;    // Faith
	public int MageSpawnRateLvl = 0;      // Grades
	
	public int ImoutoSpawnRateLvl = 0;    // Maturity
	public int OrcSpawnRateLvl = 0;       // Education
	public int SuccubusSpawnRateLvl = 0;  // Ikemen
	public int PirateSpawnRateLvl = 0;    // Pub Party
	public int WarlockSpawnRateLvl = 0;   // Spam
	
	public int GuardLvl = 0;              // Drill Trainning
	public int ElfLvl = 0;                // Rivalry
	public int DwarfLvl = 0;              // Mad Science
	public int PriestLvl = 0;             // Devotion
	public int MageLvl = 0;               // Cramming
	
	public int ImoutoLvl = 0;             // Childcare
	public int OrcLvl = 0;                // Wrestling
	public int SuccubusLvl = 0;           // Sixth Sense
	public int PirateLvl = 0;             // Arrr
	public int WarlockLvl = 0;            // Work Stress
	
	public int Money = 0;
	public int Score = 0;
	
	public int MaxLevel = -1;
	public int StartLevel = -1;
	public bool Intro = false;
}
