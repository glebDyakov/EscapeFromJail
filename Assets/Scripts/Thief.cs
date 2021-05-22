using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : KillZek {

	

	/*public void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.tag == "Bullet") {
			
			Destroy (other.gameObject);
			
			transform.GetChild(0).gameObject.SetActive(true);
			Invoke("ActiveHealth",2);
			PreDie ();
		} else if (other.gameObject.tag.Contains ("Player") && GetComponent<MoveZek>().rowOfZek == other.GetComponent<ReceiveDamageFromKickZek>().rowOfWatcher) {
			//меняем флаг на то что зек стопорится
			EnemyCop=other.gameObject;
			anima.Play("Z_A");
			GetComponent<MoveZek>().walk=false;
			
		}
	}*/

	public void ZeckAttack(){
		// вор наносит маленький урон и ворует запасы 
		if(EnemyCop){
			
			Destroy (gameObject);
			//EnemyCop.GetComponent<Animator>().Play("O_dub-1");
			//cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - cop.healthBarScale / 3f, cop.healthBar.transform.localScale.y);
		}
		/*else if(!EnemyCop){
			GetComponent<MoveZek>().walk=true;
			anima.Play("Z_R");
		}*/
	}

}
