using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyProduct : MonoBehaviour {
	//public GameObject product;
	//этот скрипт будет на кнопке "купить" к каждому товару
	public int maxCount;
	public int productPrice;
	public string productName;
	public UnityEngine.UI.Text countOfThings;
	public GameObject progressBar;


	void OnMouseUpAsButton(){
		//if (PlayerPrefs.GetInt("TextCoinsAll") >= product.GetComponent<PriceOfProduct>()) {

		//}
		if (PlayerPrefs.GetInt ("TextCoinsAll") >= productPrice) {
			//Buy product

			if (productName.Contains ("naruchniki") && PlayerPrefs.GetInt ("CountNaruchniki") < maxCount) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - productPrice);
				print ("Куплено");

				PlayerPrefs.SetInt ("CountNaruchniki", PlayerPrefs.GetInt ("CountNaruchniki") + 1);
				countOfThings.text = PlayerPrefs.GetInt ("CountNaruchniki").ToString();
			} else if (productName.Contains ("svist") && PlayerPrefs.GetInt ("CountSvist") < maxCount) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - productPrice);
				print ("Куплено");

				PlayerPrefs.SetInt ("CountSvist", PlayerPrefs.GetInt ("CountSvist") + 1);
				countOfThings.text = PlayerPrefs.GetInt ("CountSvist").ToString();
			}
		} else {
			progressBar.GetComponent<AudioSource> ().clip = progressBar.GetComponent<ButtonsClick> ().clips [1];
			progressBar.GetComponent<AudioSource> ().Play ();
			print ("не хватает денег");
			//можно здесь добавить предложения перевести игроку за реальные деньги в игровые монеты
		}
		print(PlayerPrefs.GetInt ("TextCoinsAll"));

	}
}
