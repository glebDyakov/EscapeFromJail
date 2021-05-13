using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyProduct : MonoBehaviour {
	//public GameObject product;
	//этот скрипт будет на кнопке "купить" к каждому товару
	public int productPrice;
	void OnMouseUpAsButton(){
		//if (PlayerPrefs.GetInt("TextCoinsAll") >= product.GetComponent<PriceOfProduct>()) {

		//}
		if (PlayerPrefs.GetInt ("TextCoinsAll") >= productPrice) {
			//Buy product
			PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - productPrice);
		} else {
			print ("не хватает денег");
			//можно здесь добавить предложения перевести игроку за реальные деньги в игровые монеты
		}
		print(PlayerPrefs.GetInt ("TextCoinsAll"));

	}
}
