using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thief : KillZek {




	public void ZeckAttack(){
		if(EnemyCop){
			ReceiveDamageFromKickZek cop=EnemyCop.GetComponent<ReceiveDamageFromKickZek>();
			cop.healthBar.transform.localScale = new Vector2 (cop.healthBar.transform.localScale.x - cop.healthBarScale / 3f - damage, cop.healthBar.transform.localScale.y);
			cop.OnTriggerEnter2D(gameObject.GetComponent<Collider2D>());
			//
			if(PlayerPrefs.GetInt ("CountNaruchniki")>=1){
				PlayerPrefs.SetInt ("CountNaruchniki", PlayerPrefs.GetInt ("CountNaruchniki") - 1);
				GameObject.Find("NaruchnikiAttackText").GetComponent<Text>().text = PlayerPrefs.GetInt("CountNaruchniki").ToString();
			}else if(PlayerPrefs.GetInt ("CountSvist")>=1){
				PlayerPrefs.SetInt ("CountSvist", PlayerPrefs.GetInt ("CountSvist") - 1);
				GameObject.Find("SvistAttackText").GetComponent<Text>().text = PlayerPrefs.GetInt ("CountSvist").ToString ();
			}
			print ("Наручников" + PlayerPrefs.GetInt ("CountNaruchniki"));

		}

	}


}
