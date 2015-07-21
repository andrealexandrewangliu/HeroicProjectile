using UnityEngine;
using System.Collections;

public class LevelGlobals : MonoBehaviour {
	public static int Stage = 1;
	public static float Power = 2000;
	public static float DistanceTraveled = 0;
	public static bool Paused = false;
	public static LevelGlobals LocalGlobals;
	public static float InvincibleTimer = 0;
	public static bool Invincible{
		get {
			return InvincibleTimer != 0;
		}
		set {
			if (value)
				InvincibleTimer = -1;
			else
				InvincibleTimer = 0;
		}
	}
	public BackgroundScroll BGNormal;
	public BackgroundScroll BGHigh;
	public SimpleBackgroundScroll CloudsClose;
	public SimpleBackgroundScroll CloudsLower;
	public BottomSpawner AllySpawner;
	public TopSpawner EnemySpawner;
	public SpriteRenderer HeroPropulsionRenderer;
	public MusicBGMPlayer BGM;
	public AudioClip[]StageMusic = new AudioClip[11];

	private Color PorpulsionAlpha = new Color(1,1,1,1);

	public void TogglePause(){
		Paused = !Paused;
	}

	public void SetStageBGM(int i){
		int index = i - 1;
		if (index < 0) {
			return;
		}
		else if (index >= StageMusic.Length) {
			BGM.Play(StageMusic[StageMusic.Length-1]);
		}
		else {
			BGM.Play(StageMusic[index]);
		}
	}

	private void SetSpawners(){
		AllySpawner.ChancePerDeciSecond [0] = 0.01f + (0.002f * BaseGlobalStats.GuardSpawnRateLvl);
		AllySpawner.ChancePerDeciSecond [1] = 0.01f + (0.002f * BaseGlobalStats.ElfSpawnRateLvl);
		AllySpawner.ChancePerDeciSecond [2] = 0.01f + (0.002f * BaseGlobalStats.DwarfSpawnRateLvl);
		AllySpawner.ChancePerDeciSecond [3] = 0.01f + (0.002f * BaseGlobalStats.PriestSpawnRateLvl);
		AllySpawner.ChancePerDeciSecond [4] = 0.01f + (0.002f * BaseGlobalStats.MageSpawnRateLvl);
		
		EnemySpawner.ChancePerDeciSecond [0] = 0.06f - (0.005f * BaseGlobalStats.ImoutoSpawnRateLvl);
		EnemySpawner.ChancePerDeciSecond [1] = 0.18f - (0.02f * BaseGlobalStats.OrcSpawnRateLvl);
		EnemySpawner.ChancePerDeciSecond [2] = 0.12f - (0.02f * BaseGlobalStats.SuccubusSpawnRateLvl);
		EnemySpawner.ChancePerDeciSecond [3] = 0.06f - (0.005f * BaseGlobalStats.PirateSpawnRateLvl);
		EnemySpawner.ChancePerDeciSecond [4] = 0.06f - (0.01f * BaseGlobalStats.WarlockSpawnRateLvl);
	}

	public static string PowerString{
		get{
			int finalPower = (int) Power;
			int level = 0;
			string returnString;
			while (finalPower > 10000){
				finalPower /= 1000;
				level++;
			}
			returnString = finalPower.ToString();
			switch(level){
			case 0:
				break;
			case 1:
				returnString += "K";
				break;
			case 2:
				returnString += "M";
				break;
			case 3:
				returnString += "G";
				break;
			case 4:
				returnString += "T";
				break;
			case 5:
				returnString += "P";
				break;
			default:
				returnString += "+";
				break;
			}

			return returnString;
		}
	}

	public static float StageScale{
		get{
			return GameObject.Find ("Stage").transform.localScale.y;
		}
	}

	public void NextLevel(){
		BGNormal.EndTransition ();
		BGHigh.EndTransition ();

		Stage++;
		SetStageBGM (Stage);
		AllySpawner.SpawnLevel = (Stage / 2) + (Stage % 2);
		EnemySpawner.SpawnLevel = Stage / 2;


		BGNormal.UpdateLooping ();
		BGHigh.UpdateLooping ();
	}

	// Use this for initialization
	void Start () {
		LocalGlobals = this;
		Power = BaseGlobalStats.PlayerPower;
		SetSpawners ();
	}

	public static void PowerDamage(float strength){
		if (!LevelGlobals.Invincible) {
			Power -= strength * (1.0f - BaseGlobalStats.PowerDefense);
		}
	}

	private void NextLevelVerify(){
		switch (Stage) {
		case 1:
			if (DistanceTraveled > 8000) {
				NextLevel();
			}
			break;
		case 2:
			if (DistanceTraveled > 25000) {
				NextLevel();
			}
			break;
		case 3:
			if (DistanceTraveled > 60000) {
				NextLevel();
			}
			break;
		case 4:
			if (DistanceTraveled > 150000) {
				NextLevel();
			}
			break;
		case 5:
			if (DistanceTraveled > 300000) {
				NextLevel();
			}
			break;
		case 6:
			if (DistanceTraveled > 1000000) {
				NextLevel();
			}
			break;
		case 7:
			if (DistanceTraveled > 2500000) {
				NextLevel();
			}
			break;
		case 8:
			if (DistanceTraveled > 5000000) {
				NextLevel();
			}
			break;
		case 9:
			if (DistanceTraveled > 7000000) {
				NextLevel();
			}
			break;
		case 10:
			if (DistanceTraveled > 10000000) {
				NextLevel();
			}
			break;
		}
	}


	void NoPauseUpdate(){
		if (Paused)
			return;
		float deltaTime = Time.deltaTime;
		float powerLoss = (Power * BaseGlobalStats.PowerLossRatio) + 10;
		powerLoss *= 1.0f - Priest.TotalPriestBonus;

		DistanceTraveled += Power * deltaTime;
		NextLevelVerify ();

		Power -=powerLoss * deltaTime;



		if (Power < 0)
			Power = 0;

		BGNormal.ScrollSpeed = Power ;
		BGHigh.ScrollSpeed = BGNormal.ScrollSpeed / 2.0f;
		CloudsClose.ScrollSpeed = Power * 0.8f;
		CloudsLower.ScrollSpeed = CloudsClose.ScrollSpeed / 2.0f ;

		if (Power >= 1000) {
			PorpulsionAlpha.a = 1;
		} else {
			PorpulsionAlpha.a = Power / 1000;
		}

		HeroPropulsionRenderer.color = PorpulsionAlpha;

		if (InvincibleTimer > 0) {
			InvincibleTimer -= deltaTime;
			if (InvincibleTimer < 0)
				InvincibleTimer = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		NoPauseUpdate ();
	}
}
