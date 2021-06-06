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
	public UnityEngine.UI.Text countOfMoneys;
	public UnityEngine.UI.Text ammos;
	public GameObject progressBar;
	public List<AudioClip> clips;


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
				ammos.text = "Боеприпасы: " + PlayerPrefs.GetInt ("CountNaruchniki").ToString();
				countOfMoneys.text = "Coins: " + PlayerPrefs.GetInt ("TextCoinsAll").ToString ();

				progressBar.GetComponent<AudioSource> ().clip = progressBar.GetComponent<ButtonsClick> ().clips [0];
				progressBar.GetComponent<AudioSource> ().Play ();
			} else if (productName.Contains ("svist") && PlayerPrefs.GetInt ("CountSvist") < maxCount) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - productPrice);
				print ("Куплено");

				PlayerPrefs.SetInt ("CountSvist", PlayerPrefs.GetInt ("CountSvist") + 1);
				countOfThings.text = PlayerPrefs.GetInt ("CountSvist").ToString();
				ammos.text = "Боеприпасы: " + PlayerPrefs.GetInt ("CountSvist").ToString();
				countOfMoneys.text = "Coins: " + PlayerPrefs.GetInt ("TextCoinsAll").ToString ();

				progressBar.GetComponent<AudioSource> ().clip = progressBar.GetComponent<ButtonsClick> ().clips [0];
				progressBar.GetComponent<AudioSource> ().Play ();
			} else if (productName.Contains ("Shootgun") && PlayerPrefs.GetInt ("CountShootgunAmmo") < maxCount) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - productPrice);
				print ("Куплено");

				PlayerPrefs.SetInt ("CountShootgunAmmo", PlayerPrefs.GetInt ("CountShootgunAmmo") + 5);
				countOfThings.text = PlayerPrefs.GetInt ("CountShootgunAmmo").ToString();
				ammos.text = "Боеприпасы: " + PlayerPrefs.GetInt ("CountShootgunAmmo").ToString();
				countOfMoneys.text = "Coins: " + PlayerPrefs.GetInt ("TextCoinsAll").ToString ();

				progressBar.GetComponent<AudioSource> ().clip = progressBar.GetComponent<ButtonsClick> ().clips [0];
				progressBar.GetComponent<AudioSource> ().Play ();
			} else if (productName.Contains ("Elixir") && PlayerPrefs.GetInt ("ElixirsCount") < maxCount) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - productPrice);
				print ("Куплено");

				PlayerPrefs.SetInt ("ElixirsCount", PlayerPrefs.GetInt ("ElixirsCount") + 1);
				countOfThings.text = PlayerPrefs.GetInt ("ElixirsCount").ToString();
				ammos.text = "Боеприпасы: " + PlayerPrefs.GetInt ("ElixirsCount").ToString();
				countOfMoneys.text = "Coins: " + PlayerPrefs.GetInt ("TextCoinsAll").ToString ();

				progressBar.GetComponent<AudioSource> ().clip = progressBar.GetComponent<ButtonsClick> ().clips [0];
				progressBar.GetComponent<AudioSource> ().Play ();
			} else if (productName.Contains ("DoubleCoins") && PlayerPrefs.GetInt ("DoubleCoinsEnabled") != 1) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - productPrice);
				print ("Куплено");

				PlayerPrefs.SetInt ("DoubleCoinsEnabled", 1);
				countOfThings.text = PlayerPrefs.GetInt ("DoubleCoinsEnabled").ToString();
				ammos.text = "Боеприпасы: " + PlayerPrefs.GetInt ("DoubleCoinsEnabled").ToString();
				countOfMoneys.text = "Coins: " + PlayerPrefs.GetInt ("TextCoinsAll").ToString ();

				progressBar.GetComponent<AudioSource> ().clip = progressBar.GetComponent<ButtonsClick> ().clips [0];
				progressBar.GetComponent<AudioSource> ().Play ();
			} else if (productName.Contains ("Shield") && PlayerPrefs.GetInt ("ShieldEnabled") != 1) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - productPrice);
				print ("Куплено");

				PlayerPrefs.SetInt ("ShieldEnabled", 1);
				countOfThings.text = PlayerPrefs.GetInt ("ShieldEnabled").ToString();
				ammos.text = "Боеприпасы: " + PlayerPrefs.GetInt ("ShieldEnabled").ToString();
				countOfMoneys.text = "Coins: " + PlayerPrefs.GetInt ("TextCoinsAll").ToString ();

				progressBar.GetComponent<AudioSource> ().clip = progressBar.GetComponent<ButtonsClick> ().clips [0];
				progressBar.GetComponent<AudioSource> ().Play ();
			} else if (productName.Contains ("Dirty") && PlayerPrefs.GetInt ("DirtyEnabled") != 1) {
				PlayerPrefs.SetInt ("TextCoinsAll", PlayerPrefs.GetInt ("TextCoinsAll") - productPrice);
				print ("Куплено");

				PlayerPrefs.SetInt ("DirtyEnabled", 1);
				countOfThings.text = PlayerPrefs.GetInt ("DirtyEnabled").ToString();
				ammos.text = "Боеприпасы: " + PlayerPrefs.GetInt ("DirtyEnabled").ToString();
				countOfMoneys.text = "Coins: " + PlayerPrefs.GetInt ("TextCoinsAll").ToString ();

				progressBar.GetComponent<AudioSource> ().clip = progressBar.GetComponent<ButtonsClick> ().clips [0];
				progressBar.GetComponent<AudioSource> ().Play ();
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
