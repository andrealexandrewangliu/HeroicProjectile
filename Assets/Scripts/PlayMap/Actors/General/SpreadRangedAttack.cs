using UnityEngine;
using System.Collections;

public class SpreadRangedAttack : RangedAttack {
	public int Projectiles = 1;
	public float SpreadRadians = 3.14f / 15.0f;

	protected override void Shoot(){
		if (Projectiles > 0) {
			Vector2 position2D = new Vector2(transform.position.x, transform.position.y);

			for (int i = 0; i < Projectiles; i++){
				float thetaIndex =  - (((float)(Projectiles - 1)) / 2.0f) + (float) i;
				float t = SpreadRadians * thetaIndex;
				GameObject shoot = (GameObject)Instantiate (ProjectilePrefab, 
			                                            transform.position, 
			                                            Quaternion.identity);
				shoot.GetComponent<MoveToDestination2D> ().Speed = Speed;

				Vector2 direction2D = new Vector2(Mathf.Sin(t), Mathf.Cos(t)).normalized;
				Debug.Log(direction2D.x + "," + direction2D.y);

				Vector2 endDestination;

				if (direction2D.y != 0){
					if (direction2D.y > 0)
						endDestination = position2D + direction2D * ((EndBorderY - position2D.y) / (direction2D.y));
					else{
						endDestination = position2D + direction2D * ((EndBorderYOpposite - position2D.y) / (direction2D.y));
					}
					if (direction2D.x != 0){
						if (EndBorderXPlus < endDestination.x){
							endDestination = position2D + direction2D * 
								((EndBorderXPlus - position2D.x)
								 / direction2D.x) ;
						}
						else if (EndBorderXMinus > endDestination.x){
							endDestination = position2D + direction2D * 
								((EndBorderXMinus - position2D.x)
								 / direction2D.x) ;
						}
					}
				}
				else{
					if (direction2D.x > 0){
						endDestination = direction2D * 
							((EndBorderXPlus - position2D.x)
							 / direction2D.x) ;
					}
					else{
						endDestination = direction2D * 
							((EndBorderXMinus - position2D.x)
							 / direction2D.x) ;
					}
				}


				shoot.GetComponent<MoveToDestination2D> ().Destination2D = endDestination;


				Attack normalAttack = shoot.GetComponent<Attack> ();
				if (normalAttack != null) {
					normalAttack.Strength = Strength;
				}
				BombAttack bombAttack = shoot.GetComponent<BombAttack> ();
				if (bombAttack != null) {
					bombAttack.Strength = Strength;
				}
				shoot.transform.parent = transform.parent;
				shoot.transform.localScale = new Vector3 (1, 1, 1);
			}
		}
	}
}
