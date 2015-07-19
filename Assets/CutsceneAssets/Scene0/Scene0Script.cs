using UnityEngine;
using System.Collections;

public class Scene0Script : CutscenePlayer {

	private void Scene00(){
		ActorPlayer [0].MoveActor (2, 6, 4);
		NextSceneInSeconds = 2.8f;
	}
	
	private void Scene01(){
		WriteText ("King", "Greetings young hero, I'm glad you've answered my summons.");
	}
	
	private void Scene02(){
		ActorPlayer [0].EmoteActor (2, CutsceneActorMovement.Emote.Question);
		WriteText ("Hero", "Greetings your majesty. However since when have I became a hero?");
	}
	
	private void Scene03(){
		ActorPlayer [0].EmoteActor (0, CutsceneActorMovement.Emote.Question);
		WriteText ("King", "Isn't it obvious? It's because you carry the sprite of the legendary hero himself!");
	}
	
	private void Scene04(){
		ActorPlayer [0].EmoteActor (2, CutsceneActorMovement.Emote.SweatDrop);
		WriteText ("Hero", "... Anyway why have I been summoned by your majesty?");
	}
	
	private void Scene05(){
		WriteText ("King", "The reason you've been summoned is because the demon lord has revived.");
	}
	
	private void Scene06(){
		WriteText ("King", "As such I need you assistance to defeat the demon lord.");
	}
	
	private void Scene07(){
		ActorPlayer [0].EmoteActor (2, CutsceneActorMovement.Emote.Suprised);
		WriteText ("Hero", "The demon lord?!?\nThen I suppose you've summoned me in order to offer me your guidance?");
	}
	
	private void Scene08(){
		WriteText ("Hero", "Afterall I'm only level 1.");
	}
	
	private void Scene09(){
		WriteText ("King", "That is correct, all of us here in this castle shall offer our support.");
	}
	
	private void Scene10(){
		ActorPlayer [0].EmoteActor (1, CutsceneActorMovement.Emote.Happy);
		WriteText ("Archbishop", "For instance I the archbishop shall bring you back alive whenever you perish.");
	}
	
	private void Scene11(){
		CloseText ();
		PlayMusic (-1);
		ActorPlayer [0].EmoteActor (2, CutsceneActorMovement.Emote.Silence);
		NextSceneInSeconds = 1.3f;
	}
	
	private void Scene12(){
		ActorPlayer [0].EmoteActor (2, CutsceneActorMovement.Emote.SweatDrop);
		WriteText ("Hero", "... Perish?");
	}
	
	private void Scene13(){
		ActorPlayer [0].EmoteActor (1, CutsceneActorMovement.Emote.Happy);
		WriteText ("Archbishop", "A trivial detail, but you will need my help often.");
	}
	
	private void Scene14(){
		ActorPlayer [0].EmoteActor (2, CutsceneActorMovement.Emote.SweatDrop);
		WriteText ("Hero", "... Often?");
	}
	
	private void Scene15(){
		ActorPlayer [0].EmoteActor (1, CutsceneActorMovement.Emote.Happy);
		WriteText ("Archbishop", "A trivial detail hero, those are mere trivial details.");
	}
	
	private void Scene16(){
		WriteText ("King", "Trivial details aside, let us make haste hero.\nThe demons do not wait for us!");
	}

	private void Scene17(){
		WriteText ("King", "And so young hero! Show me your butt!");
	}
	
	private void Scene18(){
		CloseText ();
		ActorPlayer [0].EmoteActor (2, CutsceneActorMovement.Emote.Suprised);
		ActorPlayer [0].EmoteActor (3, CutsceneActorMovement.Emote.Suprised);
		ActorPlayer [0].EmoteActor (4, CutsceneActorMovement.Emote.Suprised);
		ActorPlayer [0].EmoteActor (5, CutsceneActorMovement.Emote.Suprised);
		ActorPlayer [0].EmoteActor (6, CutsceneActorMovement.Emote.Suprised);
		ActorPlayer [0].EmoteActor (7, CutsceneActorMovement.Emote.Suprised);
		ActorPlayer [0].EmoteActor (8, CutsceneActorMovement.Emote.Suprised);
		NextSceneInSeconds = 1.3f;
	}
	
	private void Scene19(){
		CloseText ();
		ActorPlayer [0].EmoteActor (1, CutsceneActorMovement.Emote.Happy);
		ActorPlayer [0].EmoteActor (2, CutsceneActorMovement.Emote.Silence);
		ActorPlayer [0].EmoteActor (3, CutsceneActorMovement.Emote.Silence);
		ActorPlayer [0].EmoteActor (4, CutsceneActorMovement.Emote.Silence);
		ActorPlayer [0].EmoteActor (5, CutsceneActorMovement.Emote.Silence);
		ActorPlayer [0].EmoteActor (6, CutsceneActorMovement.Emote.Silence);
		ActorPlayer [0].EmoteActor (7, CutsceneActorMovement.Emote.Silence);
		ActorPlayer [0].EmoteActor (8, CutsceneActorMovement.Emote.Silence);
		NextSceneInSeconds = 1.3f;
	}
	
	private void Scene20(){
		ActorPlayer [0].EmoteActor (2, CutsceneActorMovement.Emote.SweatDrop);
		WriteText ("Hero", "... Excuse me your majesty? What was I supposed to do again?");
	}
	
	private void Scene21(){
		PlayMusic (1);
		WriteText ("King", "Turn around and show me your rear.");
	}
	
	private void Scene22(){
		ActorPlayer [0].EmoteActor (2, CutsceneActorMovement.Emote.Suprised);
		WriteText ("Hero", "Wait what?! Why do I have to show my rear?!");
	}
	
	private void Scene23(){
		ActorPlayer [0].EmoteActor (2, CutsceneActorMovement.Emote.Suprised);
		WriteText ("Hero", "And why do I have an ominous feeling about all of this!");
	}
	
	private void Scene24(){
		ActorPlayer [0].EmoteActor (0, CutsceneActorMovement.Emote.Frustration);
		ActorPlayer [0].JumpActor (0);
		ActorPlayer [0].PlaySE (0);
		WriteText ("King", "Just turn around show me your butt already!!");
	}
	
	private void Scene25(){
		ActorPlayer [0].EmoteActor (2, CutsceneActorMovement.Emote.Suprised);
		WriteText ("Hero", "NOOOOOOOOO!!!!");
		ActorPlayer [0].EmoteActor (0, CutsceneActorMovement.Emote.Frustration);
		ActorPlayer [0].SetActorSpeed (2, 3);
		ActorPlayer [0].SetActorSpeed (0, 6);
		ActorPlayer [0].TurnActor (2, CutsceneActorMovement.DirectionEnum.Down);
		ActorPlayer [0].MoveActor (2, 6, -2);
		ActorPlayer [0].MoveActor (0, 6, 2);
		NextSceneInSeconds = 0.5f;
	}
	
	private void Scene26(){
		CloseText ();
		SwitchScene (1);
	}
	
	private void Scene27(){
		ActorPlayer [1].PlaySE (0);
		ActorPlayer [1].MoveActor (0, -1, 12);
	}
	
	private void Scene28(){
		SwitchScene (0);
		NextSceneInSeconds = 0.01f;
	}
	
	private void Scene29(){
		ActorPlayer [0].TurnActor (3, CutsceneActorMovement.DirectionEnum.Down);
		ActorPlayer [0].TurnActor (4, CutsceneActorMovement.DirectionEnum.Down);
		ActorPlayer [0].TurnActor (5, CutsceneActorMovement.DirectionEnum.Down);
		ActorPlayer [0].TurnActor (6, CutsceneActorMovement.DirectionEnum.Down);
		ActorPlayer [0].TurnActor (7, CutsceneActorMovement.DirectionEnum.Down);
		ActorPlayer [0].TurnActor (8, CutsceneActorMovement.DirectionEnum.Down);
		ActorPlayer [0].EmoteActor (0, CutsceneActorMovement.Emote.Frustration);
		WriteText ("King", "Good grief, all I was going to do was to kick him to his journey.");
	}
	
	private void Scene30(){
		ActorPlayer [0].EmoteActor (1, CutsceneActorMovement.Emote.Happy);
		WriteText ("Archbishop", "He'll get used to it. *snicker*.");
	}
	
	private void Scene31(){
		ActorPlayer [0].PlaySE (0);
		ActorPlayer [0].JumpActor (5);
		WriteText ("Guards", "LOL Look at him flying!");
		NextSceneInSeconds = 0.50f;
	}
	
	private void Scene32(){
		ActorPlayer [0].PlaySE (0);
		ActorPlayer [0].JumpActor (8);
		WriteText ("Guards", "That sure is one way to start a journey!");
		NextSceneInSeconds = 0.50f;
	}
	
	private void Scene33(){
		ActorPlayer [0].PlaySE (0);
		ActorPlayer [0].JumpActor (3);
		WriteText ("Guards", "You serious?! lol!");
		NextSceneInSeconds = 0.50f;
	}
	
	private void Scene34(){
		ActorPlayer [0].TurnActor (0, CutsceneActorMovement.DirectionEnum.Up);
		ActorPlayer [0].EmoteActor (0, CutsceneActorMovement.Emote.Question);
		WriteText ("King", "And what are the rest of you lot laughing about?!\nYou are to acompany the hero in his journey!!");
	}
	
	private void Scene35(){
		CloseText ();
		ActorPlayer [0].TurnActor (3, CutsceneActorMovement.DirectionEnum.Left);
		ActorPlayer [0].TurnActor (4, CutsceneActorMovement.DirectionEnum.Left);
		ActorPlayer [0].TurnActor (5, CutsceneActorMovement.DirectionEnum.Left);
		ActorPlayer [0].TurnActor (6, CutsceneActorMovement.DirectionEnum.Right);
		ActorPlayer [0].TurnActor (7, CutsceneActorMovement.DirectionEnum.Right);
		ActorPlayer [0].TurnActor (8, CutsceneActorMovement.DirectionEnum.Right);
		ActorPlayer [0].EmoteActor (3, CutsceneActorMovement.Emote.Suprised);
		ActorPlayer [0].EmoteActor (4, CutsceneActorMovement.Emote.Suprised);
		ActorPlayer [0].EmoteActor (5, CutsceneActorMovement.Emote.Suprised);
		ActorPlayer [0].EmoteActor (6, CutsceneActorMovement.Emote.Suprised);
		ActorPlayer [0].EmoteActor (7, CutsceneActorMovement.Emote.Suprised);
		ActorPlayer [0].EmoteActor (8, CutsceneActorMovement.Emote.Suprised);
		NextSceneInSeconds = 1.3f;
	}
	
	private void Scene36(){
		ActorPlayer [0].EmoteActor (3, CutsceneActorMovement.Emote.Silence);
		ActorPlayer [0].EmoteActor (4, CutsceneActorMovement.Emote.Silence);
		ActorPlayer [0].EmoteActor (5, CutsceneActorMovement.Emote.Silence);
		ActorPlayer [0].EmoteActor (6, CutsceneActorMovement.Emote.Silence);
		ActorPlayer [0].EmoteActor (7, CutsceneActorMovement.Emote.Silence);
		ActorPlayer [0].EmoteActor (8, CutsceneActorMovement.Emote.Silence);
		NextSceneInSeconds = 1.3f;
	}
	
	private void Scene37(){
		ActorPlayer [0].EmoteActor (3, CutsceneActorMovement.Emote.SweatDrop);
		ActorPlayer [0].EmoteActor (4, CutsceneActorMovement.Emote.SweatDrop);
		ActorPlayer [0].EmoteActor (5, CutsceneActorMovement.Emote.SweatDrop);
		ActorPlayer [0].EmoteActor (6, CutsceneActorMovement.Emote.SweatDrop);
		ActorPlayer [0].EmoteActor (7, CutsceneActorMovement.Emote.SweatDrop);
		ActorPlayer [0].EmoteActor (8, CutsceneActorMovement.Emote.SweatDrop);
		WriteText ("Guards", "Seriously?!");
	}
	
	private void Scene38(){
		CloseText ();
		SwitchScene (1);
		NextSceneInSeconds = 0.01f;
	}
	
	private void Scene39(){
		ActorPlayer [1].PlaySE (0);
		ActorPlayer [1].MoveActor (1, -1, 12);
		NextSceneInSeconds = 0.2f;
	}
	private void Scene40(){
		ActorPlayer [1].PlaySE (0);
		ActorPlayer [1].MoveActor (2, -3, 12);
		NextSceneInSeconds = 0.2f;
	}
	private void Scene41(){
		ActorPlayer [1].PlaySE (0);
		ActorPlayer [1].MoveActor (3, -3, 14);
		NextSceneInSeconds = 0.2f;
	}
	private void Scene42(){
		ActorPlayer [1].PlaySE (0);
		ActorPlayer [1].MoveActor (4, -3, 10);
		NextSceneInSeconds = 0.2f;
	}
	private void Scene43(){
		ActorPlayer [1].PlaySE (0);
		ActorPlayer [1].MoveActor (5, -1, 9);
		NextSceneInSeconds = 0.2f;
	}
	private void Scene44(){
		ActorPlayer [1].PlaySE (0);
		ActorPlayer [1].MoveActor (6, -3, 17);
		NextSceneInSeconds = 0.2f;
	}
	private void Scene45(){
		WriteText ("And so the hero's journey to defeat the demon lord begins!");
	}



	#region implemented abstract members of CutscenePlayer
	protected override void ProcessNextScene ()
	{
		switch (SceneIndex) {
		case 0:
			Scene00();
			break;
		case 1:
			Scene01();
			break;
		case 2:
			Scene02();
			break;
		case 3:
			Scene03();
			break;
		case 4:
			Scene04();
			break;
		case 5:
			Scene05();
			break;
		case 6:
			Scene06();
			break;
		case 7:
			Scene07();
			break;
		case 8:
			Scene08();
			break;
		case 9:
			Scene09();
			break;
		case 10:
			Scene10();
			break;
		case 11:
			Scene11();
			break;
		case 12:
			Scene12();
			break;
		case 13:
			Scene13();
			break;
		case 14:
			Scene14();
			break;
		case 15:
			Scene15();
			break;
		case 16:
			Scene16();
			break;
		case 17:
			Scene17();
			break;
		case 18:
			Scene18();
			break;
		case 19:
			Scene19();
			break;
		case 20:
			Scene20();
			break;
		case 21:
			Scene21();
			break;
		case 22:
			Scene22();
			break;
		case 23:
			Scene23();
			break;
		case 24:
			Scene24();
			break;
		case 25:
			Scene25();
			break;
		case 26:
			Scene26();
			break;
		case 27:
			Scene27();
			break;
		case 28:
			Scene28();
			break;
		case 29:
			Scene29();
			break;
		case 30:
			Scene30();
			break;
		case 31:
			Scene31();
			break;
		case 32:
			Scene32();
			break;
		case 33:
			Scene33();
			break;
		case 34:
			Scene34();
			break;
		case 35:
			Scene35();
			break;
		case 36:
			Scene36();
			break;
		case 37:
			Scene37();
			break;
		case 38:
			Scene38();
			break;
		case 39:
			Scene39();
			break;
		case 40:
			Scene40();
			break;
		case 41:
			Scene41();
			break;
		case 42:
			Scene42();
			break;
		case 43:
			Scene43();
			break;
		case 44:
			Scene44();
			break;
		case 45:
			Scene45();
			break;
		default:
			EndScene();
			break;
		}
	}
	#endregion
}
