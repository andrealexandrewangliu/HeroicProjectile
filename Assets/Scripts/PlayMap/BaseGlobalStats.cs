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
			return 5 + (SaveGlobalData.SaveData.PlayerSpeedLvl * 2);
		}
	}
	public static float PlayerPower{
		get{
			return 2000 + (SaveGlobalData.SaveData.PlayerPowerLvl * 2000);
		}
	}
	public static float PowerLossRatio{
		get{
			return 0.3f - (SaveGlobalData.SaveData.PowerLossRatioLvl * 0.04f);
		}
	}
	public static float PowerDefense{
		get{
			return SaveGlobalData.SaveData.PowerDefenseLvl * 0.02f;
		}
	}


	// First Upgrades
	public static float PlayerSpeedLvl{
		get{
			return SaveGlobalData.SaveData.PlayerSpeedLvl;
		}
		set{
			SaveGlobalData.SaveData.PlayerSpeedLvl = value;
		}
	}
	public static float PlayerPowerLvl{
		get{
			return SaveGlobalData.SaveData.PlayerPowerLvl;
		}
		set{
			SaveGlobalData.SaveData.PlayerPowerLvl = value;
		}
	}     // Masochism
	public static float PowerLossRatioLvl{
		get{
			return SaveGlobalData.SaveData.PowerLossRatioLvl;
		}
		set{
			SaveGlobalData.SaveData.PowerLossRatioLvl = value;
		}
	}   // Hair Gel
	public static float PowerDefenseLvl{
		get{
			return SaveGlobalData.SaveData.PowerDefenseLvl;
		}
		set{
			SaveGlobalData.SaveData.PowerDefenseLvl = value;
		}
	}     // Muscle

	// Upgrades
	public static int GuardSpawnRateLvl{
		get{
			return SaveGlobalData.SaveData.GuardSpawnRateLvl;
		}
		set{
			SaveGlobalData.SaveData.GuardSpawnRateLvl = value;
		}
	}// Drafting
	public static int ElfSpawnRateLvl{
		get{
			return SaveGlobalData.SaveData.ElfSpawnRateLvl;
		}
		set{
			SaveGlobalData.SaveData.ElfSpawnRateLvl = value;
		}
	}       // Handsomeness
	public static int DwarfSpawnRateLvl{
		get{
			return SaveGlobalData.SaveData.DwarfSpawnRateLvl;
		}
		set{
			SaveGlobalData.SaveData.DwarfSpawnRateLvl = value;
		}
	}     // Investiment
	public static int PriestSpawnRateLvl{
		get{
			return SaveGlobalData.SaveData.PriestSpawnRateLvl;
		}
		set{
			SaveGlobalData.SaveData.PriestSpawnRateLvl = value;
		}
	}    // Faith
	public static int MageSpawnRateLvl{
		get{
			return SaveGlobalData.SaveData.MageSpawnRateLvl;
		}
		set{
			SaveGlobalData.SaveData.MageSpawnRateLvl = value;
		}
	}     // Grades

	public static int ImoutoSpawnRateLvl{
		get{
			return SaveGlobalData.SaveData.ImoutoSpawnRateLvl;
		}
		set{
			SaveGlobalData.SaveData.ImoutoSpawnRateLvl = value;
		}
	}    // Maturity
	public static int OrcSpawnRateLvl{
		get{
			return SaveGlobalData.SaveData.OrcSpawnRateLvl;
		}
		set{
			SaveGlobalData.SaveData.OrcSpawnRateLvl = value;
		}
	}       // Education
	public static int SuccubusSpawnRateLvl{
		get{
			return SaveGlobalData.SaveData.SuccubusSpawnRateLvl;
		}
		set{
			SaveGlobalData.SaveData.SuccubusSpawnRateLvl = value;
		}
	}  // Ikemen
	public static int PirateSpawnRateLvl{
		get{
			return SaveGlobalData.SaveData.PirateSpawnRateLvl;
		}
		set{
			SaveGlobalData.SaveData.PirateSpawnRateLvl = value;
		}
	}    // Pub Party
	public static int WarlockSpawnRateLvl{
		get{
			return SaveGlobalData.SaveData.WarlockSpawnRateLvl;
		}
		set{
			SaveGlobalData.SaveData.WarlockSpawnRateLvl = value;
		}
	}   // Spam
	
	public static int GuardLvl{
		get{
			return SaveGlobalData.SaveData.GuardLvl;
		}
		set{
			SaveGlobalData.SaveData.GuardLvl = value;
		}
	}             // Drill Trainning
	public static int ElfLvl{
		get{
			return SaveGlobalData.SaveData.ElfLvl;
		}
		set{
			SaveGlobalData.SaveData.ElfLvl = value;
		}
	}                // Rivalry
	public static int DwarfLvl{
		get{
			return SaveGlobalData.SaveData.DwarfLvl;
		}
		set{
			SaveGlobalData.SaveData.DwarfLvl = value;
		}
	}              // Mad Science
	public static int PriestLvl{
		get{
			return SaveGlobalData.SaveData.PriestLvl;
		}
		set{
			SaveGlobalData.SaveData.PriestLvl = value;
		}
	}             // Devotion
	public static int MageLvl{
		get{
			return SaveGlobalData.SaveData.MageLvl;
		}
		set{
			SaveGlobalData.SaveData.MageLvl = value;
		}
	}               // Cramming
	
	public static int ImoutoLvl{
		get{
			return SaveGlobalData.SaveData.ImoutoLvl;
		}
		set{
			SaveGlobalData.SaveData.ImoutoLvl = value;
		}
	}             // Childcare
	public static int OrcLvl{
		get{
			return SaveGlobalData.SaveData.OrcLvl;
		}
		set{
			SaveGlobalData.SaveData.OrcLvl = value;
		}
	}                // Wrestling
	public static int SuccubusLvl{
		get{
			return SaveGlobalData.SaveData.SuccubusLvl;
		}
		set{
			SaveGlobalData.SaveData.SuccubusLvl = value;
		}
	}           // Sixth Sense
	public static int PirateLvl{
		get{
			return SaveGlobalData.SaveData.PirateLvl;
		}
		set{
			SaveGlobalData.SaveData.PirateLvl = value;
		}
	}             // Arrr
	public static int WarlockLvl{
		get{
			return SaveGlobalData.SaveData.WarlockLvl;
		}
		set{
			SaveGlobalData.SaveData.WarlockLvl = value;
		}
	}            // Work Stress
	
	public static int Money{
		get{
			return SaveGlobalData.SaveData.Money;
		}
		set{
			SaveGlobalData.SaveData.Money = value;
		}
	}
	public static int Score{
		get{
			return SaveGlobalData.SaveData.Score;
		}
		set{
			SaveGlobalData.SaveData.Score = value;
		}
	}

	public static int MaxLevel{
		get{
			return SaveGlobalData.SaveData.MaxLevel;
		}
		set{
			SaveGlobalData.SaveData.MaxLevel = value;
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
}
